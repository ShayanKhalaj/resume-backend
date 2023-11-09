using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Comments.Requests.Queries
{
    public class GetAllCommentsRequest:IRequest<List<CommentDto>>
    {
        
    }
}
