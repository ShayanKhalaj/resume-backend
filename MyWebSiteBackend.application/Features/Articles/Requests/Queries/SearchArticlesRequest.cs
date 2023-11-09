using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;

namespace MyWebSiteBackend.application.Features.Articles.Requests.Queries
{
    public class SearchArticlesRequest:IRequest<ArticleComplexResult>
    {
        public ArticleSearchModel ArticleSearchModel { get; set; }
    }
}
