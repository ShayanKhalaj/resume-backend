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
    public class EditReferenceRequestHandler:IRequestHandler<EditReferenceRequest,OperationResult>
    {
        private readonly IReferenceRepository repo;
        private readonly IMapper mapper;

        public EditReferenceRequestHandler(IReferenceRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(EditReferenceRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Edit Reference");
            if(!await repo.IsReferenceExistedByThisId(request.ReferenceEditModel.Id))
            {
                errors.Add("مرجع با این شناسه یافت نشد");
                return op.Failed("ویرایش مرجع ناموفق", HttpStatusCode.NotFound, errors);
            }
            var validator = new EditReferenceValidator();
            var validation = await validator.ValidateAsync(request.ReferenceEditModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش مرجع ناموفق", HttpStatusCode.NotFound, errors);
            }
            var reference = mapper.Map<Reference>(request.ReferenceEditModel);
            return await repo.EditAsync(reference);
        }
    }
}
