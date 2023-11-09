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
using MyWebSiteBackend.application.Features.SubArticles.Requests.Commands;

namespace MyWebSiteBackend.application.Features.SubArticles.Handlers.Commands
{
    public class DeleteSubArticleRequestHandler:IRequestHandler<DeleteSubArticleRequest,OperationResult>
    {
        private readonly ISubArticleRepository repo;
        private readonly IMapper mapper;

        public DeleteSubArticleRequestHandler(ISubArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(DeleteSubArticleRequest request, CancellationToken cancellationToken)
        {
            List<string> errors =new List<string>();
            OperationResult op =new OperationResult("Delete Sub Article");
            if(!await repo.IsSubArticleExistedByThisId(request.Id))
            {
                errors.Add("زیر مقاله با این شناسه یافت نشد");
                return op.Failed("حذف زیر مقاله ناموفق", HttpStatusCode.NotFound, errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
