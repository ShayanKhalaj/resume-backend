using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags
{
    public class MetaTagComplexResult:IComplexObjectResult<List<MetaTagsListItem>,List<string>>
    {
        public List<MetaTagsListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
