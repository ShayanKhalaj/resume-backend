using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class Keyword:BaseModel
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
