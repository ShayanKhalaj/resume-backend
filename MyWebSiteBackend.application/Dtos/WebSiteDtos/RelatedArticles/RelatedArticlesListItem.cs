using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles
{
    public class RelatedArticlesListItem:RelatedArticleDto
    {
        public string RelationName { get; set; }
        public string ArticleTitle { get; set; }
        public string RelatedArticleTitle { get; set; }
    }
}
