using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class ArticleImage:BaseModel
    {
        public string ImageUrl { get; set; }
        public string alter { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
