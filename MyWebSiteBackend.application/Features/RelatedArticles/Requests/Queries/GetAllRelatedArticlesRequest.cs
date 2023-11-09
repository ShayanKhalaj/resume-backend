using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;

namespace MyWebSiteBackend.application.Features.RelatedArticles.Requests.Queries
{
    public class GetAllRelatedArticlesRequest:IRequest<List<RelatedArticleDto>>
    {
    }
}
