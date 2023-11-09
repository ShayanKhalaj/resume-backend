using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class RelatedArticle:BaseModel
    {
        public string RelationName { get; set; }
        public int? ArticleID { get; set; }
        public Article Article { get; set; }
        public int? RelatedID { get; set; }
        public Article Related { get; set; }
    }
}
