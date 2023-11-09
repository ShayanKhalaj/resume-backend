using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Features.SubArticles.Requests.Commands
{
    public class DeleteSubArticleRequest:IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
