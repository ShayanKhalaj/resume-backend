using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages
{
    public class SubArticleImageComplexResult:IComplexObjectResult<List<SubArticleImagesListItem>,List<string>>
    {
        public List<SubArticleImagesListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
