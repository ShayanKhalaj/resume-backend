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
    public class CreateMetaTagRequestHandler:IRequestHandler<CreateMetaTagRequest,OperationResult>
    {
        private readonly IMetaTagRepository repo;
        private readonly IMapper mapper;

        public CreateMetaTagRequestHandler(IMetaTagRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(CreateMetaTagRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =new OperationResult("Create Meta Tag");
            if(await repo.HasMetaTagDuplicatedMetaTagByThisTag(request.MetaTagCreateModel.Tag))
            {
                errors.Add("متا تگ موجود است");
                return op.Failed("ثبت متا تگ ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateMetaTagValidator();
            var validation =await validator.ValidateAsync(request.MetaTagCreateModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت متا تگ ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var metaTag = mapper.Map<MetaTag>(request.MetaTagCreateModel);
            return await repo.CreateAsync(metaTag);
        }
    }
}
