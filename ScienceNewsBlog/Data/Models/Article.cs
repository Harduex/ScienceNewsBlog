using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceNewsBlog.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string PhotoUrl { get; set; }

        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

    }
}
