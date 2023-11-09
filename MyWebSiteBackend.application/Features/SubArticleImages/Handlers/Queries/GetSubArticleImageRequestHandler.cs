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
    public class GetSubArticleImageRequestHandler:IRequestHandler<GetSubArticleImageRequest,SubArticleImageDto>
    {
        private readonly ISubArticleImageRepository repo;
        private readonly IMapper mapper;

        public GetSubArticleImageRequestHandler(ISubArticleImageRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<SubArticleImageDto> Handle(GetSubArticleImageRequest request, CancellationToken cancellationToken)
        {
            var image = await repo.GetAsync(request.Id);
            return mapper.Map<SubArticleImageDto>(image);
        }
    }
}
