using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;

namespace MyWebSiteBackend.application.Features.SubArticles.Requests.Queries
{
    public class GetSubArticleRequest:IRequest<SubArticleDto>
    {
        public int Id { get; set; }
    }
}
