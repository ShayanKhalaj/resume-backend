using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;
using MyWebSiteBackend.application.Features.SubArticles.Requests.Commands;
using MyWebSiteBackend.application.Features.SubArticles.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    [ApiController]
    public class SubArticleManagement : Controller
    {
        private readonly IMediator mediator;

        public SubArticleManagement(IMediator mediator)
        {
            this.mediator=mediator;
        }
        [Route("subArticles")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllSubArticlesRequest());
            return Ok(Json(response));
        }
        [Route("subArticles/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetSubArticleRequest{Id=id});
            return Ok(Json(response));
        }
        [Route("subArticles/search")]
        [HttpGet]
        public async Task<IActionResult> Search(SubArticleSearchModel sm)
        {
            var response = await mediator.Send(new SearchSubArticlesRequest{SubArticleSearchModel=sm});
            return Ok(Json(response));
        }
        [Route("subArticles/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]SubArticleCreateEditModel model)
        {
            var response = await mediator.Send(new CreateSubArticleRequest{SubArticleCreateModel=model});
            return Ok(Json(response));
        }
        [Route("subArticles/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] SubArticleCreateEditModel model)
        {
            var response = await mediator.Send(new EditSubArticleRequest{SubArticleEditModel=model});
            return Ok(Json(response));
        }
        [Route("subArticles/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteSubArticleRequest{Id=id});
            return Ok(Json(response));
        }
    }
}
