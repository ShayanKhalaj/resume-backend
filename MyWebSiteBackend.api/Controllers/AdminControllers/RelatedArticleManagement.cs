using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;
using MyWebSiteBackend.application.Features.RelatedArticles.Requests.Commands;
using MyWebSiteBackend.application.Features.RelatedArticles.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    [ApiController]
    public class RelatedArticleManagement : Controller
    {
        private readonly IMediator mediator;

        public RelatedArticleManagement(IMediator mediator)
        {
            this.mediator=mediator;
        }
        [Route("relatedArticles")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllRelatedArticlesRequest());
            return Ok(Json(response));
        }
        [Route("relatedArticles/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetRelatedArticleRequest{Id = id});
            return Ok(Json(response));
        }
        [Route("relatedArticles/search")]
        [HttpGet]
        public async Task<IActionResult> Search(RelatedArticleSearchModel sm)
        {
            var response = await mediator.Send(new SearchRelatedArticlesRequest{RelatedArticleSearchModel = sm});
            return Ok(Json(response));
        }
        [Route("relatedArticles/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]RelatedArticleCreateEditModel model)
        {
            var response = await mediator.Send(new CreateRelatedArticleRequest{RelatedArticleCreateModel = model});
            return Ok(Json(response));
        }
        [Route("relatedArticles/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]RelatedArticleCreateEditModel model)
        {
            var response = await mediator.Send(new EditRelatedArticleRequest{ RelatedArticleEditModel= model });
            return Ok(Json(response));
        }
        [Route("relatedArticles/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteRelatedArticleRequest{Id = id});
            return Ok(Json(response));
        }
    }
}
