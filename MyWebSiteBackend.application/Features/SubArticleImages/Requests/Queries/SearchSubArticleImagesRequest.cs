using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Requests.Queries
{
    public class SearchSubArticleImagesRequest:IRequest<SubArticleImageComplexResult>
    {
        public SubArticleImageSearchModel SubArticleImageSearchModel { get; set; }
    }
}
