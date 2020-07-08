using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> SaveEdit(Article article)
        {
            var oldArticle = articleService.GetById(article.Id);
            var obj = article;
            var file = article.NewPicture;

            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    string str = Convert.ToBase64String(fileBytes);
                    obj.Picture = str;
                }
            } 
            else
            {
                obj.Picture = oldArticle.Picture;
            }

            await Task.Run(() => articleService.Edit(obj));

            return RedirectToAction("Edit", new { id = oldArticle.Id });
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Add(Article article)
        {
            var title = article.Title;
            var content = article.Content;

            var file = article.NewPicture;
            string str;

            if (file != null)
            {
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    str = Convert.ToBase64String(fileBytes);
                }
            } else
            {
                str = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8Xw8AAoMBgDTD2qgAAAAASUVORK5CYII=";
            }
            await Task.Run(() => articleService.Add(title, content, str));

            return RedirectToAction("Index");

        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            articleService.Delete(id);

            return RedirectToAction("Index");
        }


    }
}