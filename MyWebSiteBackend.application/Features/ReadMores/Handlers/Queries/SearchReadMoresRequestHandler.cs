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

namespace MyWebSiteBackend.application.Features.ReadMores.Handlers.Queries
{
    public class SearchReadMoresRequestHandler:IRequestHandler<SearchReadMoresRequest,ReadMoreComplexResult>
    {
        private readonly IReadMoreRepository repo;

        public SearchReadMoresRequestHandler(IReadMoreRepository repo)
        {
            this.repo=repo;
        }
        public async Task<ReadMoreComplexResult> Handle(SearchReadMoresRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.ReadMoreSearchModel);
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
