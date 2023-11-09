using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;
using MyWebSiteBackend.application.Features.ArticleImages.Requests.Queries;

namespace MyWebSiteBackend.application.Features.ArticleImages.Handlers.Queries
{
    public class SearchArticleImageRequestHandler:IRequestHandler<SearchArticleImageRequest,ArticleImageComplexResult>
    {
        private readonly IArticleImageRepository repo;
        private readonly IMapper mapper;

        public SearchArticleImageRequestHandler(IArticleImageRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<ArticleImageComplexResult> Handle(SearchArticleImageRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.ArticleImageSearchModel);
            if(result.Errors!=null)
            {
                foreach(var error in result.Errors)
                {
                    result.Errors.Add(error);
                }
            }
            return result;
        }
    }
}
