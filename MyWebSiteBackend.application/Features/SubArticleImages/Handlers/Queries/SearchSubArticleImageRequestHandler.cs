using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;
using MyWebSiteBackend.application.Features.SubArticleImages.Requests.Queries;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Handlers.Queries
{
    public class SearchSubArticleImageRequestHandler:IRequestHandler<SearchSubArticleImagesRequest,SubArticleImageComplexResult>
    {
        private readonly ISubArticleImageRepository repo;
        private readonly IMapper mapper;

        public SearchSubArticleImageRequestHandler(ISubArticleImageRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<SubArticleImageComplexResult> Handle(SearchSubArticleImagesRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.SubArticleImageSearchModel);
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
