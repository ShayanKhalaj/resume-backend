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
    public class CreateCommentRequestHandler : IRequestHandler<CreateCommentRequest, OperationResult>
    {
        private readonly ICommentRepository repo;
        private readonly IMapper mapper;

        public CreateCommentRequestHandler(ICommentRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<OperationResult> Handle(CreateCommentRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Create Comment");
            if (await repo.HasCommentDuplicatedCommentByThisContent(request.CommentCreateModel.Text))
            {
                errors.Add("این نظر پیشتر ثبت شده است");
                return op.Failed("ثبت نظر ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new CreateCommentValidator();
            var validation =await validator.ValidateAsync(request.CommentCreateModel);
            if (!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت پاسخ ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var comment = mapper.Map<Comment>(request.CommentCreateModel);
            return await repo.CreateAsync(comment);
        }
    }
}
