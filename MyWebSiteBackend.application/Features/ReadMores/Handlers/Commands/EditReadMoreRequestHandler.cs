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
using MyWebSiteBackend.application.Features.ReadMores.Requests.Commands;
using MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ReadMoreValidations;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.Features.ReadMores.Handlers.Commands
{
    public class EditReadMoreRequestHandler:IRequestHandler<EditReadMoreRequest,OperationResult>
    {
        private readonly IReadMoreRepository repo;
        private readonly IMapper mapper;

        public EditReadMoreRequestHandler(IReadMoreRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(EditReadMoreRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op= new OperationResult("Edit Read More");
            if(!await repo.IsReadMoreExistedByThisId(request.ReadMoreEditModel.Id))
            {
                errors.Add("بیشتر بخوانیم با این شناسه یافت نشد");
                return op.Failed("ویرایش بیشتر بخوانیم ناموفق", HttpStatusCode.NotFound, errors);
            }
            var validator = new EditReadMoreValidator();
            var validation = await validator.ValidateAsync(request.ReadMoreEditModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ویرایش بیشتر بخوانیم ناموفق", HttpStatusCode.NotFound, errors);
            }
            var readMore = mapper.Map<ReadMore>(request.ReadMoreEditModel);
            return await repo.EditAsync(readMore);
        }
    }
}
