using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;
using MyWebSiteBackend.application.Features.SubArticles.Requests.Queries;

namespace MyWebSiteBackend.application.Features.SubArticles.Handlers.Queries
{
    public class GetAllSubArticlesRequestHandler:IRequestHandler<GetAllSubArticlesRequest, List<SubArticleDto>>
    {
        private readonly ISubArticleRepository repo;
        private readonly IMapper mapper;

        public GetAllSubArticlesRequestHandler(ISubArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<List<SubArticleDto>> Handle(GetAllSubArticlesRequest request, CancellationToken cancellationToken)
        {
            var subArticles = await repo.GetAllAsync();
            return mapper.Map<List<SubArticleDto>>(subArticles);
        }
    }
}
