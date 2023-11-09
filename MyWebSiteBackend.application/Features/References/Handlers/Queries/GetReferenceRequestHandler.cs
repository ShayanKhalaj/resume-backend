using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;
using MyWebSiteBackend.application.Features.References.Requests.Queries;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.References.Handlers.Queries
{
    public class GetReferenceRequestHandler:IRequestHandler<GetReferenceRequest,ReferenceDto>
    {
        private readonly IReferenceRepository repo;
        private readonly IMapper mapper;

        public GetReferenceRequestHandler(IReferenceRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<ReferenceDto> Handle(GetReferenceRequest request, CancellationToken cancellationToken)
        {
            var reference = await repo.GetAsync(request.Id);
            return mapper.Map<ReferenceDto>(reference);
        }
    }
}
