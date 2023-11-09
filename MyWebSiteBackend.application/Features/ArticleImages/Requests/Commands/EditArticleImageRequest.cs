using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;

namespace MyWebSiteBackend.application.Features.ArticleImages.Requests.Commands
{
    public class EditArticleImageRequest:IRequest<OperationResult>
    {
        public ArticleImageCreateEditModel ArticleImageEditModel { get; set; }
    }
}
