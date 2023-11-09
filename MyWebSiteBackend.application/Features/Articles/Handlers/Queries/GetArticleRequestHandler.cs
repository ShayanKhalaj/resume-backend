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
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;
using MyWebSiteBackend.application.Features.Articles.Requests.Queries;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Articles.Handlers.Queries
{
    public class GetArticleRequestHandler:IRequestHandler<GetArticleRequest, ArticleDto>
    {
        private readonly IArticleRepository repo;
        private readonly IMapper mapper;

        public GetArticleRequestHandler(IArticleRepository repo,IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<ArticleDto> Handle(GetArticleRequest request, CancellationToken cancellationToken)
        {
            
            var article = await repo.GetAsync(request.Id);
            return mapper.Map<ArticleDto>(article);
        }
    }
}
