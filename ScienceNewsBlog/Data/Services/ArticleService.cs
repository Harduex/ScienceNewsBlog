using ScienceNewsBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ScienceNewsBlog.Data.Services
{
    public class ArticleService : IArticleService
    {
        private ApplicationDbContext db;
        public ArticleService(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }

        public void Add(string title, string content, string photoUrl)
        {
            db.Articles.Add(new Article { Title = title, Content = content, PhotoUrl = photoUrl });
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var article = GetById(id);
            db.Articles.Remove(article);
            db.SaveChanges();
        }

        public void Edit(Article article)
        {
            var articleToEdit = db.Articles.FirstOrDefault(x => x.Id == article.Id);

            if(articleToEdit != null)
            {
                articleToEdit.Title = article.Title;
                articleToEdit.Content = article.Content;
                articleToEdit.PhotoUrl = article.PhotoUrl;
                db.SaveChanges();
            }
        }

        public IEnumerable<Article> GetAll()
        {
            var articles = db.Articles.ToList();
            articles.Reverse();

            return articles;
        }

        public Article GetById(int id)
        {
            return db.Articles.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Article> GetFeatured(int n)
        {
            var featuredArticles = GetAll().Take(n).ToList();

            return featuredArticles;
        }
    }
}
