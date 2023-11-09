using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;
using MyWebSiteBackend.application.Features.Keywords.Requests.Queries;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Keywords.Handlers.Queries
{
    public class GetKeywordRequestHandler:IRequestHandler<GetKeywordRequest, KeywordDto>
    {
        private readonly IKeywordRepository repo;
        private readonly IMapper mapper;

        public GetKeywordRequestHandler(IKeywordRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<KeywordDto> Handle(GetKeywordRequest request, CancellationToken cancellationToken)
        {
             var keyword = await repo.GetAsync(request.Id);
            return mapper.Map<KeywordDto>(keyword);
        }
    }
}
