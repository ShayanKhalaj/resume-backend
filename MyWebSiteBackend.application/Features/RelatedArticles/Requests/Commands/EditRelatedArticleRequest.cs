using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;

namespace MyWebSiteBackend.application.Features.RelatedArticles.Requests.Commands
{
    public class EditRelatedArticleRequest:IRequest<OperationResult>
    {
        public RelatedArticleCreateEditModel RelatedArticleEditModel { get; set; }
    }
}
