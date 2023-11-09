using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;

namespace MyWebSiteBackend.application.Features.Comments.Requests.Queries
{
    public class SearchCommentRequest:IRequest<CommentComplexResult>
    {
        public CommentSearchModel CommentSearchModel { get; set; }
    }
}
