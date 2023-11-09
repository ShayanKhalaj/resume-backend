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

namespace MyWebSiteBackend.application.Features.Keywords.Handlers.Queries
{
    public class SearchKeywordRequestHandler:IRequestHandler<SearchKeywordRequest,KeywordComplexResult> 
    {
        private readonly IKeywordRepository repo;

        public SearchKeywordRequestHandler(IKeywordRepository repo)
        {
            this.repo=repo;
        }
        public async Task<KeywordComplexResult> Handle(SearchKeywordRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.KeywordSearchModel);
            if(result.Errors!=null)
            {
                foreach(var error in result.Errors)
                {
                    result.Errors.Add(error);   
                }
            }
            return result;
        }
    }
}
