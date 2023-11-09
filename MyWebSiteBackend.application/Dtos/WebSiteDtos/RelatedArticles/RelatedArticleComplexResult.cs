using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles
{
    public class RelatedArticleComplexResult:IComplexObjectResult<List<RelatedArticlesListItem>,List<string>>
    {
        public List<RelatedArticlesListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
