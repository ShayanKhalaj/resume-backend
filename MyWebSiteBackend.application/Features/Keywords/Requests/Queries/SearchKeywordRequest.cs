using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;

namespace MyWebSiteBackend.application.Features.Keywords.Requests.Queries
{
    public class SearchKeywordRequest:IRequest<KeywordComplexResult>
    {
        public KeywordSearchModel KeywordSearchModel { get; set; }
    }
}
