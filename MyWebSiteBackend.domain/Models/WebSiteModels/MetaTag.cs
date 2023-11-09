using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class MetaTag:BaseModel
    {
        public string Tag { get; set; }
        public string TagName { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
