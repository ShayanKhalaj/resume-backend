using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Features.Categories.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.CategoryValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Categories.Handlers.Commands
{
    public class EditCategoryRequestHandler:IRequestHandler<EditCategoryRequest,OperationResult>
    {
        private readonly ICategoryRepository repo;
        private readonly IMapper mapper;

        public EditCategoryRequestHandler(ICategoryRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(EditCategoryRequest request, CancellationToken cancellationToken)
        {
            List<string> Errors = new List<string>();
            OperationResult op = new OperationResult("Edit Category");
            if(!await repo.IsExistedCategoryByThisIdAsync(request.CategoryAddEditModel.Id))
            {
                Errors.Add("دسته بندی با این شناسه یافت نشد");
                return op.Failed("ویرایش دسته بندی ناموفق", HttpStatusCode.NotFound, Errors);
            }
            var validator = new EditCategoryValidator();
            var validation =await validator.ValidateAsync(request.CategoryAddEditModel);
            if(!validation.IsValid)
            {
                Errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش دسته بندی ناموفق", HttpStatusCode.BadRequest, Errors);
            }
            var category = mapper.Map<Category>(request.CategoryAddEditModel);
            return await repo.EditAsync(category);
        }
    }
}
