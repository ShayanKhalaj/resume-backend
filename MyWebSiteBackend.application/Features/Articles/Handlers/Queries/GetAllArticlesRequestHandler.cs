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
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Articles.Handlers.Queries
{
    public class GetAllArticlesRequestHandler:IRequestHandler<GetAllArticlesRequest,IReadOnlyList<ArticleDto>>
    {
        private readonly IArticleRepository repo;
        private readonly IMapper mapper;

        public GetAllArticlesRequestHandler(IArticleRepository repo,IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<IReadOnlyList<ArticleDto>> Handle(GetAllArticlesRequest request, CancellationToken cancellationToken)
        {
            var articles = await repo.GetAllAsync();
            return mapper.Map<List<ArticleDto>>(articles);

        }
    }
}
