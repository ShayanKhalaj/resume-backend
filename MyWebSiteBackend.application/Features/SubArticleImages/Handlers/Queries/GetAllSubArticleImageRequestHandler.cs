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
    public class GetAllSubArticleImageRequestHandler:IRequestHandler<GetAllSubArticleImagesRequest,List<SubArticleImageDto>>
    {
        private readonly ISubArticleImageRepository repo;
        private readonly IMapper mapper;

        public GetAllSubArticleImageRequestHandler(ISubArticleImageRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<List<SubArticleImageDto>> Handle(GetAllSubArticleImagesRequest request, CancellationToken cancellationToken)
        {
            var images = await repo.GetAllAsync();
            return mapper.Map<List<SubArticleImageDto>>(images);
        }
    }
}
