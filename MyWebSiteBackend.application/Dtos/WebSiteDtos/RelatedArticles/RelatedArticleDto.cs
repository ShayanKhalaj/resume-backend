using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles
{
    public class RelatedArticleDto:BaseDto
    {
        public string RelationName { get; set; }
        public int? ArticleID { get; set; }
        public int? RelatedID { get; set; }
    }
}
