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
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.ArticleImages.Handlers.Queries
{
    public class GetArticleImageRequestHandler:IRequestHandler<GetArticleImageRequest,ArticleImageDto>
    {
        private readonly IArticleImageRepository repo;
        private readonly IMapper mapper;

        public GetArticleImageRequestHandler(IArticleImageRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<ArticleImageDto> Handle(GetArticleImageRequest request, CancellationToken cancellationToken)
        {
            var articleImage = await repo.GetAsync(request.Id);
            return mapper.Map<ArticleImageDto>(articleImage);
        }
    }
}
