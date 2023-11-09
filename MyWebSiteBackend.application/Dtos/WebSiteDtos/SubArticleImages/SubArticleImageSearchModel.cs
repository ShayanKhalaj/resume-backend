﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages
{
    public class SubArticleImageSearchModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public int SubArticleID { get; set; }
    }
}
