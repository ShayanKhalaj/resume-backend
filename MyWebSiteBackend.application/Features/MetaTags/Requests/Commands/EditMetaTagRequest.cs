using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;

namespace MyWebSiteBackend.application.Features.MetaTags.Requests.Commands
{
    public class EditMetaTagRequest:IRequest<OperationResult>
    {
        public MetaTagCreateEditModel MetaTagEditModel { get; set; }
    }
}
