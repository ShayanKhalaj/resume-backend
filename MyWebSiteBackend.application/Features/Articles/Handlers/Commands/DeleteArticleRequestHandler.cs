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
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Articles.Handlers.Commands
{
    public class DeleteArticleRequestHandler : IRequestHandler<DeleteArticleRequest, OperationResult>
    {
        private readonly IArticleRepository _repo;
        private readonly IMapper _mapper;

        public DeleteArticleRequestHandler(IArticleRepository _repo, IMapper _mapper)
        {
            this._repo = _repo;
            this._mapper = _mapper;
        }
        public async Task<OperationResult> Handle(DeleteArticleRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Delete Article");
            if (await _repo.DeleteRelatedCommentsAsync(request.Id)==false)
            {
                errors.Add("ابتدا نظرات مرتبط را حذف کنید");
                return op.Failed("Delete Article", HttpStatusCode.BadRequest, errors);
            }
            if (await _repo.DeleteRelatedImagesAsync(request.Id)==false)
            {
                errors.Add("ابتدا عکس های مرتبط را حذف کنید");
                return op.Failed("Delete Article", HttpStatusCode.BadRequest, errors);
            }
            if (await _repo.DeleteRelatedKeywordsAsync(request.Id) == false)
            {
                errors.Add("ابتدا کلید واژه های مرتبط را حذف کنید");
                return op.Failed("Delete Article", HttpStatusCode.BadRequest, errors);
            }
            if (await _repo.DeleteRelatedMetaTagsAsync(request.Id) == false)
                return op.Failed("Delete Article", HttpStatusCode.BadRequest, errors);
            {
                errors.Add("ابتدا برچسب های مرتبط را حذف کنید");
            }
            if (await _repo.DeleteRelatedReferencesAsync(request.Id) == false)
            {
                errors.Add("ابتدا مراجع مرتبط را حذف کنید");
                return op.Failed("Delete Article", HttpStatusCode.BadRequest, errors);
            }
            if (await _repo.DeleteRelatedSubArticlesAsync(request.Id) == false)
            {
                errors.Add("ابتدا زیر مقالات مرتبط را حذف کنید");
                return op.Failed("Delete Article", HttpStatusCode.BadRequest, errors);
            }
            if (!await _repo.IsArticleExistedByThisIdAsync(request.Id))
            {
                errors.Add("مقاله با این شناسه یافت نشد");
                return op.Failed("Delete Article", HttpStatusCode.BadRequest, errors);
            }

            return await _repo.DeleteAsync(request.Id);


        }
    }
}
