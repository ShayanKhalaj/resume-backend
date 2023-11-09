using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;

namespace MyWebSiteBackend.application.Features.ReadMores.Requests.Commands
{
    public class CreateReadMoreRequest:IRequest<OperationResult>
    {
        public ReadMoreCreateEditModel ReadMoreCreateModel { get; set; }
    }
}
