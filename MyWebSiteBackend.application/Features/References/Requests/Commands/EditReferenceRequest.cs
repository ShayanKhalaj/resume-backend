using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;

namespace MyWebSiteBackend.application.Features.References.Requests.Commands
{
    public class EditReferenceRequest:IRequest<OperationResult>
    {
        public ReferenceCreateEditModel ReferenceEditModel { get; set; }
    }
}
