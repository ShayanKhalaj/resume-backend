using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;
using MyWebSiteBackend.application.Features.Comments.Requests.Queries;

namespace MyWebSiteBackend.application.Features.Comments.Handlers.Queries
{
    public class SearchCommentRequestHandler:IRequestHandler<SearchCommentRequest,CommentComplexResult>
    {
        private readonly ICommentRepository repo;


        public SearchCommentRequestHandler(ICommentRepository repo )
        {
            this.repo = repo;

        }
        public async Task<CommentComplexResult> Handle(SearchCommentRequest request, CancellationToken cancellationToken)
        {
            var result = await repo.SearchAsync(request.CommentSearchModel);
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
