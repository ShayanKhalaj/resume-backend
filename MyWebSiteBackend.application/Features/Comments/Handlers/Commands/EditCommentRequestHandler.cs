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
using MyWebSiteBackend.application.Features.Comments.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.CommentValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Comments.Handlers.Commands
{
    public class EditCommentRequestHandler:IRequestHandler<EditCommentRequest,OperationResult>
    {
        private readonly ICommentRepository repo;
        private readonly IMapper mapper;

        public EditCommentRequestHandler(ICommentRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(EditCommentRequest request, CancellationToken cancellationToken)
        {
            List<string> errors =new List<string>();
            OperationResult op= new OperationResult("Answer To Comment");
            if(!await repo.IsCommentExistedByThisId(request.CommentEditModel.Id))
            {
                errors.Add("نظر بااین شناسه یافت نشد");
                return op.Failed("ثبت پاسخ ناموفق", HttpStatusCode.NotFound, errors);
            }
            var validator = new EditCommentValidator();
            var validation =await validator.ValidateAsync(request.CommentEditModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت پاسخ ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var comment = mapper.Map<Comment>(request.CommentEditModel);
            return await repo.EditAsync(comment);
        }
    }
}
