using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.MetaTags.Requests.Queries
{
    public class GetAllMetaTagsRequest:IRequest<List<MetaTagDto>>
    {
    }
}
