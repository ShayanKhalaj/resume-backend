using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Features.ReadMores.Requests.Queries;
using MyWebSiteBackend.domain.Models.WebSiteModels;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;

namespace MyWebSiteBackend.application.Features.ReadMores.Handlers.Queries
{
    public class GetAllReadMoreRequestHandler:IRequestHandler<GetAllReadMoresRequest,List<ReadMoreDto>>
    {
        private readonly IReadMoreRepository repo;
        private readonly IMapper mapper;

        public GetAllReadMoreRequestHandler(IReadMoreRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<List<ReadMoreDto>> Handle(GetAllReadMoresRequest request, CancellationToken cancellationToken)
        {
            var readMores = await repo.GetAllAsync();
            return mapper.Map<List<ReadMoreDto>>(readMores);
        }
    }
}
