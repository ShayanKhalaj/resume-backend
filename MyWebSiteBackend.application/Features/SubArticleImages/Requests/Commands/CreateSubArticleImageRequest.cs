using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Requests.Commands
{
    public class CreateSubArticleImageRequest:IRequest<OperationResult>
    {
        public SubArticleImageCreateEditModel SubArticleImageCreateModel { get; set; }
    }
}
