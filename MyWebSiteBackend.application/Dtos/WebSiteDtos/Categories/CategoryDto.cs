using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories
{
    public class CategoryDto:BaseDto
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string ImageAlter { get; set; }
    }
}
