using System.Collections.Generic;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;

namespace MyWebSiteBackend.application.Features.SubArticleImages.Requests.Queries
{
    public class GetAllSubArticleImagesRequest:IRequest<List<SubArticleImageDto>>
    {
    }
}
