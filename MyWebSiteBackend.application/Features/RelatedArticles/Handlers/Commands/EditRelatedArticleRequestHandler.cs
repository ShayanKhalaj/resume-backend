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
    public class EditRelatedArticleRequestHandler:IRequestHandler<EditRelatedArticleRequest,OperationResult>
    {
        private readonly IRelatedArticleRepository repo;
        private readonly IMapper mapper;

        public EditRelatedArticleRequestHandler(IRelatedArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(EditRelatedArticleRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =new OperationResult("Edit Related Article");
            if(!await repo.IsRelatedArticleExistedByThisId(request.RelatedArticleEditModel.Id))
            {
                errors.Add("رابطه با این شناسه موجود یافت نشد");
                return op.Failed("ویرایش رابطه ناموفق", HttpStatusCode.NotFound, errors);
            }
            var validator = new EditRelatedArticleValidator();
            var validation = await validator.ValidateAsync(request.RelatedArticleEditModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش رابطه ناموفق", HttpStatusCode.NotFound, errors);
            }
            var relatedArticle = mapper.Map<RelatedArticle>(request.RelatedArticleEditModel);
            return await repo.EditAsync(relatedArticle);
        }
    }
}
