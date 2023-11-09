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
using MyWebSiteBackend.application.Features.Articles.Requests.Queries;
using MyWebSiteBackend.application.Features.Categories.Requests.Queries;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Categories.Handlers.Queries
{
    public class GetAllCategoriesRequestHandler:IRequestHandler<GetAllCategoriesRequest,List<CategoryDto>>
    {
        private readonly ICategoryRepository repo;
        private readonly IMapper mapper;

        public GetAllCategoriesRequestHandler(ICategoryRepository repo,IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var categories = await repo.GetAllAsync();
            return mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
