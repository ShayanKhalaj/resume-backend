using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Articles.Requests.Queries
{
    public class GetArticleRequest:IRequest<ArticleDto>
    {
        public int Id { get; set; }
    }
}
