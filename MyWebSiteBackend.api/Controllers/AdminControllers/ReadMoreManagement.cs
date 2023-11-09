using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;
using MyWebSiteBackend.application.Features.ReadMores.Requests.Commands;
using MyWebSiteBackend.application.Features.ReadMores.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{

    public class ReadMoreManagement : Controller
    {
        private readonly IMediator mediator;

        public ReadMoreManagement(IMediator mediator)
        {
            this.mediator=mediator;
        }
        [Route("readMores")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllReadMoresRequest());
            return Ok(Json(response));
        }
        [Route("readMores/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetReadMoreRequest{Id = id});
            return Ok(Json(response));
        }
        [Route("readMores/search")]
        [HttpGet]
        public async Task<IActionResult> Search(ReadMoreSearchModel sm)
        {
            var response = await mediator.Send(new SearchReadMoresRequest{ReadMoreSearchModel = sm});
            return Ok(Json(response));
        }
        [Route("readMores/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ReadMoreCreateEditModel model)
        {
            var response = await mediator.Send(new CreateReadMoreRequest{ReadMoreCreateModel = model});
            return Ok(Json(response));
        }
        [Route("readMores/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]ReadMoreCreateEditModel model)
        {
            var response = await mediator.Send(new EditReadMoreRequest{ReadMoreEditModel = model});
            return Ok(Json(response));
        }
        [Route("readMores/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await mediator.Send(new DeleteReadMoreRequest{Id = id});
            return Ok(Json(response));
        }
    }
}
