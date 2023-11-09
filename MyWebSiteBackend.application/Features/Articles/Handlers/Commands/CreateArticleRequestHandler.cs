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
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;
using MyWebSiteBackend.application.Features.Articles.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ArticleValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Articles.Handlers.Commands
{
    public class CreateArticleRequestHandler : IRequestHandler<CreateArticleRequest, OperationResult>
    {
        private readonly IArticleRepository _repo;
        private readonly IMapper _mapper;

        public CreateArticleRequestHandler(IArticleRepository _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        public async Task<OperationResult> Handle(CreateArticleRequest request, CancellationToken cancellationToken)
        {

            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Create Article");
            if (await _repo.HasDuplicatedTitleAsync(request.ArticleCreateModel.Title))
            {
                errors.Add("مقاله با این عنوان موجود است");
                return op.Failed("ثبت مقاله ناموفق", HttpStatusCode.BadRequest, errors);
            }
            if (await _repo.HasDuplicatedTitleByThisIdAsync(request.ArticleCreateModel.Id))
            {
                errors.Add("مقاله با این شناسه موجود است");
                return op.Failed("ثبت مقاله ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateArticleValidator();
            var validation =await validator.ValidateAsync(request.ArticleCreateModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت مقاله ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var article = _mapper.Map<Article>(request.ArticleCreateModel);
            return await _repo.CreateAsync(article);

        }
    }
}
