using AutoMapper;
using MediatR;
using MyWebSiteBackend.application.common;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Features.RelatedArticles.Requests.Commands;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace MyWebSiteBackend.application.Features.RelatedArticles.Handlers.Commands
{
    public class DeleteRelatedArticleRequestHandler:IRequestHandler<DeleteRelatedArticleRequest,OperationResult>
    {
        private readonly IRelatedArticleRepository repo;
        private readonly IMapper mapper;

        public DeleteRelatedArticleRequestHandler(IRelatedArticleRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(DeleteRelatedArticleRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op = new OperationResult("Delete Related Article");
            if(!await repo.IsRelatedArticleExistedByThisId(request.Id))
            {
                errors.Add("رابطه با این شناسه یافت نشد");
                return op.Failed("حذف رابطه ناموفق", HttpStatusCode.NotFound, errors);
            }
            return await repo.DeleteAsync(request.Id);
        }
    }
}
