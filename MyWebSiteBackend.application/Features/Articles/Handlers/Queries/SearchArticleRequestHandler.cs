using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;
using MyWebSiteBackend.application.Features.Articles.Requests.Queries;

namespace MyWebSiteBackend.application.Features.Articles.Handlers.Queries
{
    public class SearchArticleRequestHandler : IRequestHandler<SearchArticlesRequest, ArticleComplexResult>
    {
        private readonly IArticleRepository _repo;
        private readonly IMapper _mapper;

        public SearchArticleRequestHandler(IArticleRepository _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        public async Task<ArticleComplexResult> Handle(SearchArticlesRequest request, CancellationToken cancellationToken)
        {
            var result = await _repo.SearchAsync(request.ArticleSearchModel);
            if (result.Errors != null)
            {
                foreach (var err in result.Errors)
                {
                    result.Errors.Add(err);
                }
            }
            return result;
        }
    }
}
