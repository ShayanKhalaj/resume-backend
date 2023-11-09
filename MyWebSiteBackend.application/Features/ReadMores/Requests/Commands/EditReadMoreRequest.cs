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
    public class EditReadMoreRequest:IRequest<OperationResult>
    {
        public ReadMoreCreateEditModel ReadMoreEditModel { get; set; }
    }
}
