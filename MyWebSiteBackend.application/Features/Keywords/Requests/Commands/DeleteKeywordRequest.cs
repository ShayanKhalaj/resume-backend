using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;

namespace MyWebSiteBackend.application.Features.Keywords.Requests.Commands
{
    public class DeleteKeywordRequest:IRequest<OperationResult>
    {
        public int Id { get; set; }
    }
}
