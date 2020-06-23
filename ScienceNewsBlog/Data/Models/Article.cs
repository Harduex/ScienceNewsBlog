﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ScienceNewsBlog.Data.Models
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("Title: ")]
        public string Title { get; set; }

        [DisplayName("Content: ")]
        public string Content { get; set; }

        [DisplayName("Photo Url: ")]
        public string PhotoUrl { get; set; }


    }
}
