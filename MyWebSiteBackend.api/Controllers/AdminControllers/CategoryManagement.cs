using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Framework.Utilities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;
using MyWebSiteBackend.application.Features.Categories.Requests.Commands;
using MyWebSiteBackend.application.Features.Categories.Requests.Queries;

namespace MyWebSiteBackend.api.Controllers.AdminControllers
{
    [ApiController]
    public class CategoryManagement : Controller
    {
        private readonly IMediator mediator;

        public CategoryManagement(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //[Authorize(Roles="admin")]
        [Route("categories")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await mediator.Send(new GetAllCategoriesRequest());
            return Ok(Json(categories));
        }
        [Route("categories/search")]
        [HttpPost]
        public async Task<IActionResult> Search([FromBody]CategorySearchModel sm)
        {
            var response = await mediator.Send(new SearchCategoryRequest { CategorySearchModel = sm });
            return Ok(Json(response));
        }

        [Route("categories/{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var category = await mediator.Send(new GetCategoryRequest { Id = id });
            return Ok(Json(category));
        }

        [Route("categories/create")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoryAddEditModel categoryAddEditModel)
        {
                var response = await mediator.Send(new CreateCategoryRequest { CategoryAddEditModel = categoryAddEditModel });
                return Ok(Json(response));
            
        }


        [Route("categories/edit")]
        [HttpPut]
        public async Task<ActionResult> Edit([FromBody] CategoryAddEditModel categoryAddEditModel)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(new EditCategoryRequest { CategoryAddEditModel = categoryAddEditModel });
                return Json(response);
            }
            else
            {
                var errors = new
                {
                    error = "اطلاعات وارد شده صحیح نمیباشد"
                    ,
                    time = new DateTime().ToPersianCalendar()
                    ,
                    status = HttpStatusCode.BadRequest
                };
                return Json(errors);
            }
        }

        [Route("categories/delete/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await mediator.Send(new DeleteCategoryRequest { Id = id });
            return Json(response);
        }


    }
}
