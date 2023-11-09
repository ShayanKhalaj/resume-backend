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
   public class EditSubArticleRequestHandler:IRequestHandler<EditSubArticleRequest,OperationResult>
    {
        private readonly ISubArticleRepository repo;
        private readonly IMapper mapper;

        public EditSubArticleRequestHandler(ISubArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(EditSubArticleRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =new OperationResult("Edit Sub Article");
            if(!await repo.IsSubArticleExistedByThisId(request.SubArticleEditModel.Id))
            {
                errors.Add("زیر مقاله با این شناسه یافت نشد");
                return op.Failed("ویرایش زیر مقاله ناموفق", HttpStatusCode.NotFound, errors);
            }
            var validator = new EditSubArticleValidator();
            var validation = await validator.ValidateAsync(request.SubArticleEditModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش زیر مقاله ناموفق", HttpStatusCode.NotFound, errors);
            }
            var subArticle = mapper.Map<SubArticle>(request.SubArticleEditModel);
            return await repo.EditAsync(subArticle);
        }
    }
}
