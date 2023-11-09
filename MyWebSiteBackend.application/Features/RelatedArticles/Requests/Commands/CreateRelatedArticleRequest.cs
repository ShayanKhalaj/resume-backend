using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.RelatedArticles.Requests.Commands
{
    public class CreateRelatedArticleRequest:IRequest<OperationResult>
    {
        public RelatedArticleCreateEditModel RelatedArticleCreateModel { get; set; }
    }
}
