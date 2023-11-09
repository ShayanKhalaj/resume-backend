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
using MyWebSiteBackend.application.Features.References.Requests.Commands;

namespace MyWebSiteBackend.application.Features.References.Handlers.Commands
{
    public class DeleteReferenceRequestHandler:IRequestHandler<DeleteReferenceRequest,OperationResult>
    {
        private readonly IReferenceRepository repo;
        private readonly IMapper mapper;

        public DeleteReferenceRequestHandler(IReferenceRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(DeleteReferenceRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =new OperationResult("Delete Reference");
            if(!await repo.IsReferenceExistedByThisId(request.Id))
            {
                errors.Add("مرجع با این شناسه یافت نشد");
                return op.Failed("حذف مرجع ناموفق", HttpStatusCode.NotFound, errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
