using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages
{
    public class ArticleImageDto:BaseDto
    {
        public string ImageUrl { get; set; }
        public string alter { get; set; }
        public int ArticleID { get; set; }
    }
}
