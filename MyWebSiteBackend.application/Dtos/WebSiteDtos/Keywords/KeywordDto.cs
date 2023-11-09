using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords
{
    public class KeywordDto:BaseDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public int ArticleID { get; set; }
    }
}
