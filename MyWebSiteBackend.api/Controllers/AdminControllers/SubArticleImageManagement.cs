using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;
using MyWebSiteBackend.application.Features.SubArticleImages.Requests.Commands;
using MyWebSiteBackend.application.Features.SubArticleImages.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    [ApiController]
    public class SubArticleImageManagement : Controller
    {
        private readonly IMediator mediator;

        public SubArticleImageManagement(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [Route("subArticleImages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllSubArticleImagesRequest());
            return Ok(Json(response));
        }
        [Route("subArticleImages/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetSubArticleImageRequest{Id=id});
            return Ok(Json(response));
        }
        [Route("subArticleImages/search")]
        [HttpGet]
        public async Task<IActionResult> Search(SubArticleImageSearchModel sm)
        {
            var response = await mediator.Send(new SearchSubArticleImagesRequest{SubArticleImageSearchModel=sm});
            return Ok(Json(response));
        }
        [Route("subArticleImages/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubArticleImageCreateEditModel model)
        {
            var response = await mediator.Send(new CreateSubArticleImageRequest{SubArticleImageCreateModel=model});
            return Ok(Json(response));
        }
        [Route("subArticleImages/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] SubArticleImageCreateEditModel model)
        {
            var response = await mediator.Send(new EditSubArticleImageRequest{SubArticleImageEditMdoel=model});
            return Ok(Json(response));
        }
        [Route("subArticleImages/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteSubArticleImageRequest{ Id = id });
            return Ok(Json(response));
        }
    }
}
