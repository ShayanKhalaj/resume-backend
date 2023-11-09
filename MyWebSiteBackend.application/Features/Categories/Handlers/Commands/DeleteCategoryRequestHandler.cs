using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Features.Categories.Requests.Commands;

namespace MyWebSiteBackend.application.Features.Categories.Handlers.Commands
{
    public class DeleteCategoryRequestHandler:IRequestHandler<DeleteCategoryRequest,OperationResult>
    {
        private readonly ICategoryRepository repo;

        public DeleteCategoryRequestHandler(ICategoryRepository repo)
        {
            this.repo=repo;
        }
        public async Task<OperationResult> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            OperationResult op = new OperationResult("Delete Category");
            List<string> Errors = new List<string>();
            if(!await repo.IsExistedCategoryByThisIdAsync(request.Id))
            {
                Errors.Add("دسته بندی با این شناسه یافت نشد");
                return op.Failed("حذف دسته بندی ناموفق", HttpStatusCode.BadRequest, Errors);
            }
            if(await repo.DeleteRelatedArticlesByThisId(request.Id)==false)
            {
                Errors.Add("ابتدا مقالات مرتبط را حذف کنید");
                return op.Failed("حذف دسته بندی ناموفق", HttpStatusCode.BadGateway, Errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
