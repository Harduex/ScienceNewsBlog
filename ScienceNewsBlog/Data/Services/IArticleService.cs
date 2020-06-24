using ScienceNewsBlog.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceNewsBlog.Data.Services
{
    public interface IArticleService
    {
        IEnumerable<Article> GetAll();

        IEnumerable<Article> GetFeatured(int n);

        Article GetById(int id);

        void Edit(Article article);

        void Add(string title, string content, string photoUrl);

        void Delete(int id);
    }
}
