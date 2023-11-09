using MediatR;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Requests.Commands
{
    public class DeleteSubArticleImageRequest:IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
