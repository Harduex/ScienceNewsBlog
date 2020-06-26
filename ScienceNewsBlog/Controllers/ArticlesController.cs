using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScienceNewsBlog.Data.Models;
using ScienceNewsBlog.Data.Services;

namespace ScienceNewsBlog.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IActionResult Index()
        {
            var articles = articleService.GetAll();

            return View(articles);
        }

        public IActionResult Article(int id)
        {
            var article = articleService.GetById(id);

            return View(article);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var article = articleService.GetById(id);
            return View(article);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult SaveEdit(Article article)
        {
            articleService.Edit(article);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Add([Required]string title, [Required]string content, [Required]string photoUrl)
        {
            if (ModelState.IsValid)
            {
                articleService.Add(title, content, photoUrl);
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Message"] = "Fields can't be empty!";
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            articleService.Delete(id);

            return RedirectToAction("Index");
        }


    }
}