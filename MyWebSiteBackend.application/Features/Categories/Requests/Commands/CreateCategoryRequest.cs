using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;

namespace MyWebSiteBackend.application.Features.Categories.Requests.Commands
{
    public class CreateCategoryRequest:IRequest<OperationResult>
    {
        public CategoryAddEditModel CategoryAddEditModel { get; set; }
    }
}
