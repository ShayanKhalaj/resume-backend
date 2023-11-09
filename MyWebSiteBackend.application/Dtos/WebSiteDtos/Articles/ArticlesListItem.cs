using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles
{
    public class ArticlesListItem:ArticleDto
    {
        public string CategoryName { get; set; }
    }
}
