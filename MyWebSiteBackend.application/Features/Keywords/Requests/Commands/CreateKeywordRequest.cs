using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;

namespace MyWebSiteBackend.application.Features.Keywords.Requests.Commands
{
    public class CreateKeywordRequest:IRequest<OperationResult>
    {
        public KeywordCreateEditModel KeywordCreateModel { get; set; }
    }
}
