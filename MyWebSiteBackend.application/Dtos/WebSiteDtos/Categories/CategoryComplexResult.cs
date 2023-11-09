using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories
{
    public class CategoryComplexResult:IComplexObjectResult<List<CategoryListItem>,List<string>>
    {
        public List<CategoryListItem> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}
