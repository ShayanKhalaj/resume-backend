using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.References.Requests.Queries
{
    public class GetReferenceRequest:IRequest<ReferenceDto>
    {
        public int Id { get; set; }
    }
}
