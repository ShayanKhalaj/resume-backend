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
using MyWebSiteBackend.application.Features.ReadMores.Requests.Commands;

namespace MyWebSiteBackend.application.Features.ReadMores.Handlers.Commands
{
    public class DeleteReadMoreRequestHandler:IRequestHandler<DeleteReadMoreRequest,OperationResult>
    {
        private readonly IReadMoreRepository repo;

        public DeleteReadMoreRequestHandler(IReadMoreRepository repo)
        {
            this.repo=repo;
        }
        public async Task<OperationResult> Handle(DeleteReadMoreRequest request, CancellationToken cancellationToken)
        {
            List<string> errors =new List<string>();
            OperationResult op = new OperationResult("Delete Read More");
            if(!await repo.IsReadMoreExistedByThisId(request.Id))
            {
                errors.Add("بیشتر بخوانیم با این شناسه یافت نشد");
                return op.Failed("حذف بیشتر بخوانیم ناموفق", HttpStatusCode.NotFound, errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
