using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;

namespace MyWebSiteBackend.application.Features.SubArticles.Requests.Commands
{
    public class EditSubArticleRequest:IRequest<OperationResult>
    {
        public SubArticleCreateEditModel SubArticleEditModel { get; set; }
    }
}
