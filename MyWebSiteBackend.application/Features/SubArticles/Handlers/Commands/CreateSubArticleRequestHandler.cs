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
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.SubArticleValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.SubArticles.Handlers.Commands
{
    public class CreateSubArticleRequestHandler:IRequestHandler<CreateSubArticleRequest,OperationResult>
    {
        private readonly ISubArticleRepository repo;
        private readonly IMapper mapper;

        public CreateSubArticleRequestHandler(ISubArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(CreateSubArticleRequest request, CancellationToken cancellationToken)
        {
            List<string> errors =new List<string>();
            OperationResult op =new OperationResult("Create Sub Article");
            if(await repo.HasSubArticleDuplicatedSubArticleByThisTitle(request.SubArticleCreateModel.Title))
            {
                errors.Add("زیر مقاله با این عنوان موجود است");
                return op.Failed("ثبت زیر مقاله ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateSubArticleValidator();
            var validation = await validator.ValidateAsync(request.SubArticleCreateModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت زیر مقاله ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var subArticle = mapper.Map<SubArticle>(request.SubArticleCreateModel);
            return await repo.CreateAsync(subArticle);
        }
    }
}
