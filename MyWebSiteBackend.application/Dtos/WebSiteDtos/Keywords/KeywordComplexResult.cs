using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords
{
    public class KeywordComplexResult:IComplexObjectResult<List<KeywordsListItem> ,List<string>>
    {
        public List<KeywordsListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
