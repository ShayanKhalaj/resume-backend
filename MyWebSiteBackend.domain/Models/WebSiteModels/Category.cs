using System;
using System.Collections.Generic;
using System.Text;

namespace MyWebSiteBackend.domain.Models.WebSiteModels
{
    public class Category:BaseModel
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlter { get; set; }
        public ICollection<Article> Articles { get; set; }

        public Category()
        {
            this.Articles=new List<Article>();
        }
    }
}
