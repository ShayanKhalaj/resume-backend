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
using MyWebSiteBackend.application.Features.MetaTags.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.MetaTagValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.MetaTags.Handlers.Commands
{
    public class EditMetaTagRequestHandler:IRequestHandler<EditMetaTagRequest,OperationResult>
    {
        private readonly IMetaTagRepository repo;
        private readonly IMapper mapper;

        public EditMetaTagRequestHandler(IMetaTagRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(EditMetaTagRequest request, CancellationToken cancellationToken)
        {
            List<string> errors =new List<string>();
            OperationResult op =new OperationResult("Edit Meta Tag");
            if(!await repo.IsMetaTagExistedByThisId(request.MetaTagEditModel.Id))
            {
                errors.Add("متا تگ با این شناسه یافت نشد");
                return op.Failed("ویرایش متا تگ ناموفق", HttpStatusCode.NotFound, errors);
            }
            var validator = new EditMetaTagValidator();
            var validation =await validator.ValidateAsync(request.MetaTagEditModel);
            if(!validation.IsValid)
            {

                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش متا تگ ناموفق", HttpStatusCode.NotFound, errors);
            }
            var metaTag = mapper.Map<MetaTag>(request.MetaTagEditModel);
            return await repo.EditAsync(metaTag);
        }
    }
}
