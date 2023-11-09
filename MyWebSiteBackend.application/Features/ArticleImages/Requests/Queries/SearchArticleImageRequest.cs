using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;

namespace MyWebSiteBackend.application.Features.ArticleImages.Requests.Queries
{
    public class SearchArticleImageRequest:IRequest<ArticleImageComplexResult>
    {
        public ArticleImageSearchModel ArticleImageSearchModel { get; set; }
    }
}
