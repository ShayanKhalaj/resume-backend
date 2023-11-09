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
    public class GetAllArticleImagesRequestHandler:IRequestHandler<GetAllArticleImagesRequest,List<ArticleImageDto>>
    {
        private readonly IArticleImageRepository repo;
        private readonly IMapper mapper;

        public GetAllArticleImagesRequestHandler(IArticleImageRepository repo,IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<List<ArticleImageDto>> Handle(GetAllArticleImagesRequest request, CancellationToken cancellationToken)
        {
            var articleImages =  await repo.GetAllAsync();
            return mapper.Map<List<ArticleImageDto>>(articleImages);
        }
    }
}
