using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;
using MyWebSiteBackend.application.Features.Keywords.Requests.Commands;
using MyWebSiteBackend.application.Features.Keywords.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    public class KeywordManagement : Controller
    {
        private readonly IMediator mediator;

        public KeywordManagement(IMediator mediator)
        {
            this.mediator=mediator;
        }
        [Route("keywords")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await mediator.Send(new GetAllKeywordsRequest());
            return Ok(response);
        }
        [Route("keywords/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var response = await mediator.Send(new GetKeywordRequest{Id = id});
            return Ok(response);
        }
        
        [Route("keywords/search")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody]KeywordSearchModel sm)
        {
            var response = await mediator.Send(new SearchKeywordRequest { KeywordSearchModel = sm });
            return Ok(response);
        }
        [Route("keywords/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]KeywordCreateEditModel model)
        {
            var response = await mediator.Send(new CreateKeywordRequest { KeywordCreateModel = model });
            return Ok(response);
        }
        [Route("keywords/edit")]
        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]KeywordCreateEditModel model)
        {
            var response = await mediator.Send(new EditKeywordRequest{ KeywordEditModel = model });
            return Ok(response);
        }
        [Route("keywords/delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteKeywordRequest{ Id = id});
            return Ok(response);
        }
    }
}
