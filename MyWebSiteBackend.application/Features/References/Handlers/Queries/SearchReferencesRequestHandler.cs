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

namespace MyWebSiteBackend.application.Features.References.Handlers.Queries
{
    public class SearchReferencesRequestHandler:IRequestHandler<SearchReferencesRequest,ReferenceComplexResult>
    {
        private readonly IReferenceRepository repo;
        private readonly IMapper mapper;

        public SearchReferencesRequestHandler(IReferenceRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<ReferenceComplexResult> Handle(SearchReferencesRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.ReferenceSearchModel);
            return mapper.Map<ReferenceComplexResult>(result);
        }
    }
}
