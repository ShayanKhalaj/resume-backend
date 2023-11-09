using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;
using MyWebSiteBackend.application.Features.References.Requests.Commands;
using MyWebSiteBackend.application.Features.References.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    [ApiController]
    public class ReferenceManagement : Controller
    {
        private readonly IMediator mediator;

        public ReferenceManagement(IMediator mediator)
        {
            this.mediator=mediator;
        }
        [Route("references")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllReferencesRequest());
            return Ok(Json(response));
        }
        [Route("references/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetReferenceRequest{Id=id});
            return Ok(Json(response));
        }
        [Route("references/search")]
        [HttpGet]
        public async Task<IActionResult> Search(ReferenceSearchModel sm)
        {
            var response = await mediator.Send(new SearchReferencesRequest{ReferenceSearchModel=sm});
            return Ok(Json(response));
        }
        [Route("references/create")]
        [HttpPost]
        public async Task<IActionResult> Create(ReferenceCreateEditModel model)
        {
            var response = await mediator.Send(new CreateReferenceRequest{ReferenceCreateModel=model});
            return Ok(Json(response));
        }
        [Route("references/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit(ReferenceCreateEditModel model)
        {
            var response = await mediator.Send(new EditReferenceRequest{ReferenceEditModel=model});
            return Ok(Json(response));
        }
        [Route("references/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteReferenceRequest{Id=id});
            return Ok(Json(response));
        }
    }
}
