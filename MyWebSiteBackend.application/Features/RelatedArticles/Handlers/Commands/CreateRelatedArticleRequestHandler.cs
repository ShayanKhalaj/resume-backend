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
using MyWebSiteBackend.application.Features.RelatedArticles.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.RelatedArticlesValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.RelatedArticles.Handlers.Commands
{
    public class CreateRelatedArticleRequestHandler:IRequestHandler<CreateRelatedArticleRequest,OperationResult>
    {
        private readonly IRelatedArticleRepository repo;
        private readonly IMapper mapper;

        public CreateRelatedArticleRequestHandler(IRelatedArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(CreateRelatedArticleRequest request, CancellationToken cancellationToken)
        {
            List<string> errors=new List<string>();
            OperationResult op =new OperationResult("Create Related Article");
            if(await repo.HasRelatedArticleDuplicatedRelatedArticlesByThisName(request.RelatedArticleCreateModel.RelationName))
            {
                errors.Add("رابطه با این نام موجود است");
                return op.Failed("ثبت رابطه ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateRelatedArticleValidator();
            var validation = await validator.ValidateAsync(request.RelatedArticleCreateModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت رابطه ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var relatedArticle = mapper.Map<RelatedArticle>(request.RelatedArticleCreateModel);
            return await repo.CreateAsync(relatedArticle);
        }
    }
}
