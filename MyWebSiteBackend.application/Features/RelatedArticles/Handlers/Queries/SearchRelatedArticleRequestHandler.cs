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
    public class SearchRelatedArticleRequestHandler:IRequestHandler<SearchRelatedArticlesRequest ,RelatedArticleComplexResult>
    {
        private readonly IRelatedArticleRepository repo;
        private readonly IMapper mapper;

        public SearchRelatedArticleRequestHandler(IRelatedArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<RelatedArticleComplexResult> Handle(SearchRelatedArticlesRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.RelatedArticleSearchModel);
            if(result.Errors!=null)
            {
                foreach(var error in result.Errors)
                {
                    result.Errors.Add(error);
                }
            }
            return mapper.Map<RelatedArticleComplexResult>(result);
        }
    }
}
