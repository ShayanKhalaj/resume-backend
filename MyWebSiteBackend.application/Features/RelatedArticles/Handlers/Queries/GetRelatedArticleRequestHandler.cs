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
    public class GetRelatedArticleRequestHandler:IRequestHandler<GetRelatedArticleRequest,RelatedArticleDto>
    {
        private readonly IRelatedArticleRepository repo;
        private readonly IMapper mapper;

        public GetRelatedArticleRequestHandler(IRelatedArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<RelatedArticleDto> Handle(GetRelatedArticleRequest request, CancellationToken cancellationToken)
        {
            var relatedArticle = await repo.GetAsync(request.Id);
            return mapper.Map<RelatedArticleDto>(relatedArticle);
        }
    }
}
