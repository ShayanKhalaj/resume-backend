using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles
{
    public class SubArticleComplexResult:IComplexObjectResult<List<SubArticlesListItem>,List<string>>
    {
        public List<SubArticlesListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
