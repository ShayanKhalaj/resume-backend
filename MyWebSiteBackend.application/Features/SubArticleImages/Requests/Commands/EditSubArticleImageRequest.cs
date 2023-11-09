using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Requests.Commands
{
    public class EditSubArticleImageRequest:IRequest<OperationResult>
    {
        public SubArticleImageCreateEditModel SubArticleImageEditMdoel { get; set; }
    }
}
