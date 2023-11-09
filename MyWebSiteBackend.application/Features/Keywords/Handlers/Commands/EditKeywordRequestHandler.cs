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
using MyWebSiteBackend.application.Features.Keywords.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.KeywordValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.Keywords.Handlers.Commands
{
    public class EditKeywordRequestHandler:IRequestHandler<EditKeywordRequest,OperationResult>
    {
        private readonly IKeywordRepository repo;
        private readonly IMapper mapper;

        public EditKeywordRequestHandler(IKeywordRepository repo,IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<OperationResult> Handle(EditKeywordRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op =new OperationResult("Edit Keyword");
            if(!await repo.IsKeywordExistedByThisId(request.KeywordEditModel.Id))
            {
                errors.Add("کلید واژه با این شناسه یافت نشد");
                return op.Failed("ویرایش کلید واژه ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator = new EditKeywordValidator();
            var validation =await validator.ValidateAsync(request.KeywordEditModel);
            if (!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش پاسخ ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var keyword = mapper.Map<Keyword>(request.KeywordEditModel);
            return await repo.EditAsync(keyword);
        }
    }
}
