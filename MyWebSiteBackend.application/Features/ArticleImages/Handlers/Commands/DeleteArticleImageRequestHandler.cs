using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Features.ArticleImages.Requests.Commands;

namespace MyWebSiteBackend.application.Features.ArticleImages.Handlers.Commands
{
    public class DeleteArticleImageRequestHandler:IRequestHandler<DeleteArticleImageRequest,OperationResult>
    {
        private readonly IArticleImageRepository repo;

        public DeleteArticleImageRequestHandler(IArticleImageRepository repo)
        {
            this.repo=repo;
        }
        public async Task<OperationResult> Handle(DeleteArticleImageRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Delete Article Image");
            if (!await repo.IsArticleImageExistedByThisId(request.Id))
            {
                errors.Add("عکس با این شناسه یافت نشد");
                return op.Failed("حذف عکس ناموفق", HttpStatusCode.BadRequest, errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
