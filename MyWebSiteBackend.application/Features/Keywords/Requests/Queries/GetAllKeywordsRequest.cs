using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Keywords.Requests.Queries
{
    public class GetAllKeywordsRequest:IRequest<List<KeywordDto>>
    {
    }
}
