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
using MyWebSiteBackend.application.Features.Articles.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ArticleValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Articles.Handlers.Commands
{
    public class EditArticleRequestHandler : IRequestHandler<EditArticleRequest, OperationResult>
    {
        private readonly IArticleRepository _repo;
        private readonly IMapper _mapper;

        public EditArticleRequestHandler(IArticleRepository _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        public async Task<OperationResult> Handle(EditArticleRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Edit Article");
            if (!await _repo.IsArticleExistedByThisIdAsync(request.ArticleEditModel.Id))
            {
                errors.Add("مقاله با این شناسه یافت نشد");
                return op.Failed("ویرایش مقاله ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new EditArticleValidator();
            var validation =await validator.ValidateAsync(request.ArticleEditModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش مقاله ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var article = _mapper.Map<Article>(request.ArticleEditModel);
            return await _repo.EditAsync(article);
        }
    }
}
