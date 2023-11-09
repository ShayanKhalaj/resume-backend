using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;
using MyWebSiteBackend.application.Features.Comments.Requests.Commands;
using MyWebSiteBackend.application.Features.Comments.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    public class CommentManagement : Controller
    {
        private readonly IMediator mediator;

        public CommentManagement(IMediator mediator)
        {
            this.mediator=mediator;
        }
        [Route("comments")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllCommentsRequest());
            return Ok(Json(response));
        }
        [Route("comments/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetCommentRequest { Id = id });
            return Ok(Json(response));
        }
        [Route("comments/search")]
        [HttpGet]
        public async Task<IActionResult> Search(CommentSearchModel sm)
        {
            var response = await mediator.Send(new SearchCommentRequest { CommentSearchModel = sm });
            return Ok(response);
        }
        [Route("comments/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CommentCreateEditModel model)
        {
            var response = await mediator.Send(new CreateCommentRequest { CommentCreateModel = model });
            return Ok(Json(response));
        }
        [Route("comments/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]CommentCreateEditModel model)
        {
            var response = await mediator.Send(new EditCommentRequest { CommentEditModel= model });
            return Ok(Json(response));
        }
        [Route("comments/delete/{id}")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteCommentRequest { Id = id });
            return Ok(Json(response));
        }
        
    }
}
