using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.References
{
    public class ReferenceDto:BaseDto
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public int ArticleID { get; set; }
    }
}
