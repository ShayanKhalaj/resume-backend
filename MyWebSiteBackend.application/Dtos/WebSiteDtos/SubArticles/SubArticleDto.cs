using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles
{
    public class SubArticleDto:BaseDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
        public string AudioUrl { get; set; }
        public string AudioDescription { get; set; }
        public int ArticleID { get; set; }
    }
}
