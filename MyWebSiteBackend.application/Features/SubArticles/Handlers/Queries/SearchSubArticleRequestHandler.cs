using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;
using MyWebSiteBackend.application.Features.SubArticles.Requests.Queries;

namespace MyWebSiteBackend.application.Features.SubArticles.Handlers.Queries
{
    public class SearchSubArticleRequestHandler:IRequestHandler<SearchSubArticlesRequest,SubArticleComplexResult>
    {
        private readonly ISubArticleRepository repo;
        private readonly IMapper mapper;

        public SearchSubArticleRequestHandler(ISubArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<SubArticleComplexResult> Handle(SearchSubArticlesRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.SubArticleSearchModel);
            if(result.Errors!=null)
            {
                foreach(var error in result.Errors)
                {
                    result.Errors.Add(error);
                }
            }
            return mapper.Map<SubArticleComplexResult>(result);
        }
    }
}
