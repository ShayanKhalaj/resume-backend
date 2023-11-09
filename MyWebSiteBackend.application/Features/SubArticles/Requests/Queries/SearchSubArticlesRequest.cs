using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;

namespace MyWebSiteBackend.application.Features.SubArticles.Requests.Queries
{
    public class SearchSubArticlesRequest:IRequest<SubArticleComplexResult>
    {
        public SubArticleSearchModel SubArticleSearchModel { get; set; }
    }
}
