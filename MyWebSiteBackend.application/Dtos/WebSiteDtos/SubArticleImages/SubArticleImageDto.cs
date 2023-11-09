using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages
{
    public class SubArticleImageDto:BaseDto
    {
        public string ImageUrl { get; set; }
        public string Alter { get; set; }
        public int SubArticleID { get; set; }
    }
}
