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
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;
using MyWebSiteBackend.application.Features.SubArticleImages.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.SubArticleImageValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Handlers.Commands
{
    public class EditSubArticleImageRequestHandler:IRequestHandler<EditSubArticleImageRequest,OperationResult>
    {
        private readonly ISubArticleImageRepository repo;
        private readonly IMapper mapper;

        public EditSubArticleImageRequestHandler(ISubArticleImageRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(EditSubArticleImageRequest request, CancellationToken cancellationToken)
        {
            List<string> errors  =new List<string>();
            OperationResult op =new OperationResult("Edit Sub Article Image");
            if(!await repo.IsSubArticleImageExistedByThisId(request.SubArticleImageEditMdoel.Id))
            {
                errors.Add("عکس با این شناسه یافت نشد");
                return op.Failed("ویرایش عکس ناموفق", HttpStatusCode.NotFound, errors);
            }
            var validator = new EditSubArticleImageValidator();
            var validation = await validator.ValidateAsync(request.SubArticleImageEditMdoel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش عکس ناموفق", HttpStatusCode.NotFound, errors);
            }
            var image = mapper.Map<SubArticleImage>(request.SubArticleImageEditMdoel);
            return await repo.EditAsync(image);
        }
    }
}
