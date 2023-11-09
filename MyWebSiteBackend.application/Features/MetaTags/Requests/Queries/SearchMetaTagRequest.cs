using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;

namespace MyWebSiteBackend.application.Features.MetaTags.Requests.Queries
{
    public class SearchMetaTagRequest:IRequest<MetaTagComplexResult>
    {
        public MetaTagSearchModel MetaTagSearchModel { get; set; }
    }
}
