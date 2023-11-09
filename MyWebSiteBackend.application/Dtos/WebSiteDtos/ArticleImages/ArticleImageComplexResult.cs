using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages
{
    public class ArticleImageComplexResult:IComplexObjectResult<List<ArticleImageListItem>,List<string>>
    {
        public List<ArticleImageListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
