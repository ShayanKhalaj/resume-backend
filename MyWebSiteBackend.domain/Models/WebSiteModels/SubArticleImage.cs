using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class SubArticleImage:BaseModel
    {
        public string ImageUrl { get; set; }
        public string Alter { get; set; }
        public int SubArticleID { get; set; }
        public SubArticle SubArticle { get; set; }
    }
}
