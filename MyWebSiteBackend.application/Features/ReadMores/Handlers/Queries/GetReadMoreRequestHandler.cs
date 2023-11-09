using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;
using MyWebSiteBackend.application.Features.ReadMores.Requests.Queries;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.ReadMores.Handlers.Queries
{
    public class GetReadMoreRequestHandler:IRequestHandler<GetReadMoreRequest,ReadMoreDto>
    {
        private readonly IReadMoreRepository repo;
        private readonly IMapper mapper;

        public GetReadMoreRequestHandler(IReadMoreRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<ReadMoreDto> Handle(GetReadMoreRequest request, CancellationToken cancellationToken)
        {
            var readMore = await repo.GetAsync(request.Id);
            return mapper.Map<ReadMoreDto>(readMore);
        }
    }
}
