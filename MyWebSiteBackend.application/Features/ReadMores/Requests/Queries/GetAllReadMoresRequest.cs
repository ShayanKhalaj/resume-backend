using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.ReadMores.Requests.Queries
{
   public  class GetAllReadMoresRequest:IRequest<List<ReadMoreDto>>
    {
    }
}
