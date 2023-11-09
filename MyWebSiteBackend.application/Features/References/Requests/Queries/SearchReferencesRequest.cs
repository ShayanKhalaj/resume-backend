using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;

namespace MyWebSiteBackend.application.Features.References.Requests.Queries
{
    public class SearchReferencesRequest:IRequest<ReferenceComplexResult>
    {
        public ReferenceSearchModel ReferenceSearchModel { get; set; }
    }
}
