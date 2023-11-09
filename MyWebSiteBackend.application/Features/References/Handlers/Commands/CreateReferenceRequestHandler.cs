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
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ReferenceValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.References.Handlers.Commands
{
    public class CreateReferenceRequestHandler:IRequestHandler<CreateReferenceRequest,OperationResult>
    {
        private readonly IReferenceRepository repo;
        private readonly IMapper mapper;

        public CreateReferenceRequestHandler(IReferenceRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(CreateReferenceRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Create Reference");
            if(await repo.HasReferenceDuplicatedReferencesByThisNameAndLink(request.ReferenceCreateModel.Name,request.ReferenceCreateModel.Link))
            {
                errors.Add("مرجع با این مشخصات موجود است");
                return op.Failed("ثبت مرجع ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateReferenceValidator();
            var validation = await validator.ValidateAsync(request.ReferenceCreateModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت مرجع ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var reference = mapper.Map<Reference>(request.ReferenceCreateModel);
            return await repo.CreateAsync(reference);
        }
    }
}
