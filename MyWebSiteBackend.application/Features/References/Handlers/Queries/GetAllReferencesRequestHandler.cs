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
    public class GetAllReferencesRequestHandler:IRequestHandler<GetAllReferencesRequest,List<ReferenceDto>>
    {
        private readonly IReferenceRepository repo;
        private readonly IMapper mapper;

        public GetAllReferencesRequestHandler(IReferenceRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<List<ReferenceDto>> Handle(GetAllReferencesRequest request, CancellationToken cancellationToken)
        {
            var references = await repo.GetAllAsync();
            return mapper.Map<List<ReferenceDto>>(references);
        }
    }
}
