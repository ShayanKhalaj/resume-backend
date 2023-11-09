using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;

namespace MyWebSiteBackend.application.Features.Categories.Requests.Queries
{
    public class SearchCategoryRequest:IRequest<CategoryComplexResult>
    {
        public CategorySearchModel CategorySearchModel { get; set; }
    }
}
