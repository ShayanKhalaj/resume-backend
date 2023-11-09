using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;
using MyWebSiteBackend.application.Features.Categories.Requests.Queries;

namespace MyWebSiteBackend.application.Features.Categories.Handlers.Queries
{
    public class SearchCategoryRequestHandler:IRequestHandler<SearchCategoryRequest,CategoryComplexResult>
    {
        private readonly ICategoryRepository repo;

        public SearchCategoryRequestHandler(ICategoryRepository repo)
        {
            this.repo=repo;
        }
        public async Task<CategoryComplexResult> Handle(SearchCategoryRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.CategorySearchModel);
            if(result.Errors!=null)
            {
                foreach(var errors in result.Errors)
                {
                    result.Errors.Add(errors);
                }
            }
            return result;
        }
    }
}
