using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags
{
    public class MetaTagDto:BaseDto
    {
        public string Tag { get; set; }
        public string TagName { get; set; }
        public int ArticleID { get; set; }
    }
}
