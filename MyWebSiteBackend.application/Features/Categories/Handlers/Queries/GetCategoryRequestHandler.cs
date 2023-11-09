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
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Categories.Handlers.Queries
{
    public class GetCategoryRequestHandler:IRequestHandler<GetCategoryRequest,CategoryDto>
    {
        private readonly ICategoryRepository repo;
        private readonly IMapper mapper;

        public GetCategoryRequestHandler(ICategoryRepository repo,IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<CategoryDto> Handle(GetCategoryRequest request, CancellationToken cancellationToken)
        {
            var category =  await repo.GetAsync(request.Id);
            return mapper.Map<CategoryDto>(category);
        }
    }
}
