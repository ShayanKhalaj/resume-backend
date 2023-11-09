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
    public class GetSubArticleRequestHandler:IRequestHandler<GetSubArticleRequest,SubArticleDto>
    {
        private readonly ISubArticleRepository repo;
        private readonly IMapper mapper;

        public GetSubArticleRequestHandler(ISubArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<SubArticleDto> Handle(GetSubArticleRequest request, CancellationToken cancellationToken)
        {
            var subArticle = await repo.GetAsync(request.Id);
            return mapper.Map<SubArticleDto>(subArticle);
        }
    }
}
