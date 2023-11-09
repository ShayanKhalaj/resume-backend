using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Features.Comments.Requests.Commands
{
    public class DeleteCommentRequest:IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
