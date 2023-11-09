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
using MyWebSiteBackend.application.Features.MetaTags.Requests.Commands;

namespace MyWebSiteBackend.application.Features.MetaTags.Handlers.Commands
{
    public class DeleteMetaTagRequestHandler:IRequestHandler<DeleteMetaTagRequest,OperationResult>
    {
        private readonly IMetaTagRepository repo;

        public DeleteMetaTagRequestHandler(IMetaTagRepository repo)
        {
            this.repo=repo;
        }
        public async Task<OperationResult> Handle(DeleteMetaTagRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =  new OperationResult("Delete Meta Tag");
            if(!await repo.IsMetaTagExistedByThisId(request.Id))
            {
                errors.Add("متا تگ با این شناسه یافت نشد");
                return op.Failed("حذف متا تگ ناموفق", HttpStatusCode.NotFound, errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
