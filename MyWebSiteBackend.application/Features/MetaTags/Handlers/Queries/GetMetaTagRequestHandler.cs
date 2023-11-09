using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;
using MyWebSiteBackend.application.Features.MetaTags.Requests.Queries;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.MetaTags.Handlers.Queries
{
    public class GetMetaTagRequestHandler:IRequestHandler<GetMetaTagRequest,MetaTagDto>
    {
        private readonly IMetaTagRepository repo;
        private readonly IMapper mapper;

        public GetMetaTagRequestHandler(IMetaTagRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<MetaTagDto> Handle(GetMetaTagRequest request, CancellationToken cancellationToken)
        {
            var metaTag =  await repo.GetAsync(request.Id);
            return mapper.Map<MetaTagDto>(metaTag);
        }
    }
}
