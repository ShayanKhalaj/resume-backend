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
    public class GetAllKeywordsRequestHandler:IRequestHandler<GetAllKeywordsRequest,List<KeywordDto>>
    {
        private readonly IKeywordRepository repo;
        private readonly IMapper mapper;

        public GetAllKeywordsRequestHandler(IKeywordRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<List<KeywordDto>> Handle(GetAllKeywordsRequest request, CancellationToken cancellationToken)
        {
            var keywords = await repo.GetAllAsync();
            return mapper.Map<List<KeywordDto>>(keywords);
        }
    }
}
