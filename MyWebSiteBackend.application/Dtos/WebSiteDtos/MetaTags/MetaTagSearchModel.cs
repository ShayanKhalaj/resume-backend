using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags
{
    public class MetaTagSearchModel
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string TagName { get; set; }
        public string Description { get; set; }
        public int ArticleID { get; set; }
    }
}
