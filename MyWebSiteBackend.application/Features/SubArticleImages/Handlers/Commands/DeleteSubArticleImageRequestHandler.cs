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
using MyWebSiteBackend.application.Features.SubArticleImages.Requests.Commands;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Handlers.Commands
{
    public class DeleteSubArticleImageRequestHandler:IRequestHandler<DeleteSubArticleImageRequest,OperationResult>
    {
        private readonly ISubArticleImageRepository repo;

        public DeleteSubArticleImageRequestHandler(ISubArticleImageRepository repo)
        {
            this.repo=repo;
        }
        public async Task<OperationResult> Handle(DeleteSubArticleImageRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =new OperationResult("Delete Sub Article Image");
            if(!await  repo.IsSubArticleImageExistedByThisId(request.Id))
            {
                errors.Add("زیر مقاله با این شناسه یافت نشد");
                return op.Failed("حذف زیر مقاله ناموفق", HttpStatusCode.NotFound, errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
