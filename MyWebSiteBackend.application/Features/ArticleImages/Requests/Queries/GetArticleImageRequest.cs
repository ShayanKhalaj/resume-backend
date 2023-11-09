using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.ArticleImages.Requests.Queries
{
    public class GetArticleImageRequest:IRequest<ArticleImageDto>
    {
        public int Id { get; set; }
    }
}
