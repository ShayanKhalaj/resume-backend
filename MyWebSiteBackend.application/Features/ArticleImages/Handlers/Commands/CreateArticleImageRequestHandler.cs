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
    public class CreateArticleImageRequestHandler : IRequestHandler<CreateArticleImageRequest, OperationResult>
    {
        private readonly IArticleImageRepository repo;
        private readonly IMapper mapper;

        public CreateArticleImageRequestHandler(IArticleImageRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<OperationResult> Handle(CreateArticleImageRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Create Article Image");
            if (await repo.HasArticleImageDuplicatedArticleImageByThisUrl(request.ArticleImageCreateModel.ImageUrl))
            {
                errors.Add("عکس با این آدرس موجود است");
                return op.Failed("ثبت عکس ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateArticleImageValidator();
            var validation =await validator.ValidateAsync(request.ArticleImageCreateModel);
            if (!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت عکس ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var articleImage = mapper.Map<ArticleImage>(request.ArticleImageCreateModel);
            return await repo.CreateAsync(articleImage);
        }
    }
}
