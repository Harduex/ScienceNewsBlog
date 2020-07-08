using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceNewsBlog.Data.Models
{
    public class Article
    {
        public Article()
        {
            this.CreatedDate = DateTime.UtcNow;
        }

        public int Id { get; set; }

        [DisplayName("Title: ")]
        public string Title { get; set; }

        [DisplayName("Content: ")]
        public string Content { get; set; }

        [NotMapped]
        public IFormFile NewPicture { get; set; }

        [DisplayName("Picture: ")]
        public string Picture { get; set; }

        public DateTime CreatedDate { get; set; }


    }
}
