using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;

namespace MyWebSiteBackend.application.Features.ReadMores.Requests.Queries
{
    public class SearchReadMoresRequest:IRequest<ReadMoreComplexResult>
    {
        public ReadMoreSearchModel ReadMoreSearchModel { get; set; }
    }
}
