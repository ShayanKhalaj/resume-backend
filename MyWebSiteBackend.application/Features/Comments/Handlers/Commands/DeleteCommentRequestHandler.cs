using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Features.Comments.Requests.Commands;

namespace MyWebSiteBackend.application.Features.Comments.Handlers.Commands
{
    public class DeleteCommentRequestHandler:IRequestHandler<DeleteCommentRequest,OperationResult>
    {
        private readonly ICommentRepository repo;

        public DeleteCommentRequestHandler(ICommentRepository repo)
        {
            this.repo=repo;
        }
        public async Task<OperationResult> Handle(DeleteCommentRequest request, CancellationToken cancellationToken)
        {
            List<string> errors=new List<string>();
            OperationResult op =new OperationResult("Delete Comment");
            if(!await repo.IsCommentExistedByThisId(request.Id))
            {
                errors.Add("نظر با این شناسه یافت نشد");
                return op.Failed("حذف نظر ناموفق", HttpStatusCode.BadRequest, errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
