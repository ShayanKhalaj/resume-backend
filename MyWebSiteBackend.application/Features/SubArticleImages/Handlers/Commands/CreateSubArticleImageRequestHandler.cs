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
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;
using MyWebSiteBackend.application.Features.SubArticleImages.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.SubArticleImageValidations;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.SubArticleValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Handlers.Commands
{
    public class CreateSubArticleImageRequestHandler:IRequestHandler<CreateSubArticleImageRequest,OperationResult>
    {
        private readonly ISubArticleImageRepository repo;
        private readonly IMapper mapper;

        public CreateSubArticleImageRequestHandler(ISubArticleImageRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(CreateSubArticleImageRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =new OperationResult("Create Sub Article Image");
            if(await repo.HasSubArticleImageDuplicatedSubArticleImageByThisUrl(request.SubArticleImageCreateModel.ImageUrl))
            {
                errors.Add("عکس با این آدرس موجود است");
                return op.Failed("ثبت عکس ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateSubArticleImageValidator();
            var validation = await validator.ValidateAsync(request.SubArticleImageCreateModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت عکس ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var image = mapper.Map<SubArticleImage>(request.SubArticleImageCreateModel);
            return await repo.CreateAsync(image);
        }
    }
}
