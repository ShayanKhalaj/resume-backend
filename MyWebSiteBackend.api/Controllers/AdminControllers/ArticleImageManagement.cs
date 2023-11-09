using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;
using MyWebSiteBackend.application.Features.ArticleImages.Requests.Commands;
using MyWebSiteBackend.application.Features.ArticleImages.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    public class ArticleImageManagement : Controller
    {
        private readonly IMediator mediator;

        public ArticleImageManagement(IMediator mediator)
        {
            this.mediator=mediator;
        }
        
        [Route("articleImages")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllArticleImagesRequest());
            return Ok(Json(response));
        }
        [Route("articleImages/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetArticleImageRequest { Id = id });
            return Ok(Json(response));
        }
        [Route("articleImages/search")]
        [HttpGet]
        public async Task<IActionResult> Search(ArticleImageSearchModel sm)
        {
            var response = await mediator.Send(new SearchArticleImageRequest { ArticleImageSearchModel = sm });
            return Ok(Json(response));
        }
        [Route("articleImages/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteArticleImageRequest { Id = id });
            return Ok(Json(response));
        }
        [Route("articleImages/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]ArticleImageCreateEditModel model)
        {
            var response = await mediator.Send(new EditArticleImageRequest { ArticleImageEditModel = model });
            return Ok(Json(response));
        }
        [Route("articleImages/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ArticleImageCreateEditModel model)
        {
            var response = await mediator.Send(new CreateArticleImageRequest { ArticleImageCreateModel = model });
            return Ok(Json(response));
        }
    }
}
