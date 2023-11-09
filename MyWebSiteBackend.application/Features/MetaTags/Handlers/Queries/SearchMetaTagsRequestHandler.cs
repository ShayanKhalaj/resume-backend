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

namespace MyWebSiteBackend.application.Features.MetaTags.Handlers.Queries
{
    public class SearchMetaTagsRequestHandler:IRequestHandler<SearchMetaTagRequest,MetaTagComplexResult>
    {
        private readonly IMetaTagRepository repo;
        

        public SearchMetaTagsRequestHandler(IMetaTagRepository repo)
        {
            this.repo=repo;

        }
        public async Task<MetaTagComplexResult> Handle(SearchMetaTagRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.MetaTagSearchModel);
            if (result.Errors != null)
            {
                foreach (var error in result.Errors)
                {
                    result.Errors.Add(error);
                }
            }
            return result;
        }
    }
}
