using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class ReadMore:BaseModel
    {
        public string LinkName { get; set; }
        public string LinkText { get; set; }
        public int SubArticleID { get; set; }
        public SubArticle SubArticle { get; set; }
    }
}
