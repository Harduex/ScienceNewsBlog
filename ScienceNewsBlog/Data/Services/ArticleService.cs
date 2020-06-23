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
        private ApplicationDbContext dbContext;
        public ArticleService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Article> GetAll()
        {
            return dbContext.Articles.ToList();
        }
    }
}
