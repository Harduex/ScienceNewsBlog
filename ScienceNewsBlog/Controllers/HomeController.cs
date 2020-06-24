using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ScienceNewsBlog.Data.Models;
using ScienceNewsBlog.Data.Services;
using ScienceNewsBlog.Models;

namespace ScienceNewsBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleService articleService;

        public HomeController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        public IActionResult Index()
        {
            var articles = articleService.GetFeatured(3);

            return View(articles);
        }

        public IActionResult Articles()
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
        [Route("Home/Edit/{id}")]
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

            return RedirectToAction("Articles");
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
                return RedirectToAction("Articles");
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

            return RedirectToAction("Articles");
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
