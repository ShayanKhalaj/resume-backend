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
using MyWebSiteBackend.application.Features.ArticleImages.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ArticleImageValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.ArticleImages.Handlers.Commands
{
    public class EditArticleImageRequestHandler : IRequestHandler<EditArticleImageRequest, OperationResult>
    {
        private readonly IArticleImageRepository repo;
        private readonly IMapper mapper;

        public EditArticleImageRequestHandler(IArticleImageRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<OperationResult> Handle(EditArticleImageRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Edit Article Image");
            if (!await repo.IsArticleImageExistedByThisId(request.ArticleImageEditModel.Id))
            {
                errors.Add("عکس با این شناسه یافت نشد");
                return op.Failed("ویرایش عکس ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new EditArticleImageValidator();
            var validation =await validator.ValidateAsync(request.ArticleImageEditModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش عکس ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var articleImage = mapper.Map<ArticleImage>(request.ArticleImageEditModel);
            return await repo.EditAsync(articleImage);
        }
    }
}
