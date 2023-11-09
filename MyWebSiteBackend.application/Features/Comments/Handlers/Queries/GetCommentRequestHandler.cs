using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;
using MyWebSiteBackend.application.Features.Comments.Requests.Queries;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Comments.Handlers.Queries
{
    public class GetCommentRequestHandler:IRequestHandler<GetCommentRequest,CommentDto>
    {
        private readonly ICommentRepository repo;
        private readonly IMapper mapper;

        public GetCommentRequestHandler(ICommentRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<CommentDto> Handle(GetCommentRequest request, CancellationToken cancellationToken)
        {
            var comment = await repo.GetAsync(request.Id);
            return mapper.Map<CommentDto>(comment);
        }
    }
}
