using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages
{
    public class ArticleImageSearchModel
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ArticleID { get; set; }
    }
}
