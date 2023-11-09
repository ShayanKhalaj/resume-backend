using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;

namespace MyWebSiteBackend.application.Features.Comments.Requests.Commands
{
    public class EditCommentRequest:IRequest<OperationResult>
    {
        public CommentCreateEditModel CommentEditModel { get; set; }
    }
}
