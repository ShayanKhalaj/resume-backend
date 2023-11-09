using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles
{
    public class ArticleDto:BaseDto
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
        public string AudioUrl { get; set; }
        public string AudioDescription { get; set; }
        public int Rate { get; set; }
        public int CategoryID { get; set; }
    }
}
