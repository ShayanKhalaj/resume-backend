using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;
using MyWebSiteBackend.application.Features.RelatedArticles.Requests.Queries;

namespace MyWebSiteBackend.application.Features.RelatedArticles.Handlers.Queries
{
    public class GetAllRelatedArticlesRequestHandler:IRequestHandler<GetAllRelatedArticlesRequest,List<RelatedArticleDto>>
    {
        private readonly IRelatedArticleRepository repo;
        private readonly IMapper mapper;

        public GetAllRelatedArticlesRequestHandler(IRelatedArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<List<RelatedArticleDto>> Handle(GetAllRelatedArticlesRequest request, CancellationToken cancellationToken)
        {
            var relatedArticles = await repo.GetAllAsync();
            return mapper.Map<List<RelatedArticleDto>>(relatedArticles);
        }
    }
}
