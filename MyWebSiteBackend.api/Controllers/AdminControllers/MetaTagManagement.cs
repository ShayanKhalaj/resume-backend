using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;
using MyWebSiteBackend.application.Features.MetaTags.Requests.Commands;
using MyWebSiteBackend.application.Features.MetaTags.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    public class MetaTagManagement : Controller
    {
        private readonly IMediator mediator;

        public MetaTagManagement(IMediator mediator)
        {
            this.mediator=mediator;
        }
        [Route("tags")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllMetaTagsRequest());
            return Ok(Json(response));
        }
        [Route("tags/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetMetaTagRequest{Id = id});
            return Ok(Json(response));
        }
        [Route("tags/search")]
        [HttpGet]
        public async Task<IActionResult> Search(MetaTagSearchModel sm)
        {
            var response = await mediator.Send(new SearchMetaTagRequest{MetaTagSearchModel = sm});
            return Ok(Json(response));
        }
        [Route("tags/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MetaTagCreateEditModel model)
        {
            var response = await mediator.Send(new CreateMetaTagRequest{MetaTagCreateModel = model});
            return Ok(Json(response));
        }
        [Route("tags/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]MetaTagCreateEditModel model)
        {
            var response = await mediator.Send(new EditMetaTagRequest{MetaTagEditModel = model});
            return Ok(Json(response));
        }
        [Route("tags/delete{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteMetaTagRequest{ Id = id });
            return Ok(Json(response));
        }
    }
}
