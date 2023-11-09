using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles
{
    public class ArticleComplexResult:IComplexObjectResult<List<ArticlesListItem>,List<string>>
    {
        public List<ArticlesListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
