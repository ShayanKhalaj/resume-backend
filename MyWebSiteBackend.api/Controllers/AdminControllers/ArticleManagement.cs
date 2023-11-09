using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;
using MyWebSiteBackend.application.Features.Articles.Handlers.Commands;
using MyWebSiteBackend.application.Features.Articles.Requests.Commands;
using MyWebSiteBackend.application.Features.Articles.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    //[Authorize("admin")]
    [ApiController]
    public class ArticleManagement : Controller
    {
        private readonly IMediator _mediator;

        public ArticleManagement(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("articles")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var request = await _mediator.Send(new GetAllArticlesRequest());
            return Ok(Json(request));
            
        }

        [Route("articles/search")]
        [HttpPost]
        public async Task<IActionResult> Search(ArticleSearchModel sm)
        {
            var result = await _mediator.Send(new SearchArticlesRequest{ArticleSearchModel = sm});
            return Ok(Json(result));
        }
        

        [Route("articles/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetArticleRequest{Id = id});
            return Ok(Json(result));
        }

        [Route("articles/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleCreateEditModel model)
        {
            var result = await _mediator.Send(new CreateArticleRequest { ArticleCreateModel = model });
            return Ok(Json(result));

        }

        [Route("articles/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]ArticleCreateEditModel model)
        {
            var result = await _mediator.Send(new EditArticleRequest { ArticleEditModel = model });
            return Ok(Json(result));
        }

        [Route("articles/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteArticleRequest{Id = id});
            return Ok(Json(result));
        }
    }
}
