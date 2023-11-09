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
using MyWebSiteBackend.application.Features.Keywords.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.KeywordValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Keywords.Handlers.Commands
{
    public class CreateKeywordRequestHandler:IRequestHandler<CreateKeywordRequest,OperationResult>
    {
        private readonly IKeywordRepository repo;
        private readonly IMapper mapper;

        public CreateKeywordRequestHandler(IKeywordRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(CreateKeywordRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =new OperationResult("Create Keyword");
            if(await repo.HasKeywordDuplicatedKeywordsByThisName(request.KeywordCreateModel.Name))
            {
                errors.Add("کلید واژه با این نام موجود است");
                return op.Failed("ثبت کلید واژه ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateKeywordValidator();
            var validation =await validator.ValidateAsync(request.KeywordCreateModel);
            if (!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت پاسخ ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var keyword = mapper.Map<Keyword>(request.KeywordCreateModel);
            return await repo.CreateAsync(keyword);
        }
    }
}
