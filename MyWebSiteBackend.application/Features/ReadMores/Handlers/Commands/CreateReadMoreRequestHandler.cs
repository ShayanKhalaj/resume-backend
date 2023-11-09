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
    public class CreateReadMoreRequestHandler:IRequestHandler<CreateReadMoreRequest,OperationResult>
    {
        private readonly IReadMoreRepository repo;
        private readonly IMapper mapper;

        public CreateReadMoreRequestHandler(IReadMoreRepository repo, IMapper mapper)
        {
            this.repo=repo;
            this.mapper=mapper;
        }
        public async Task<OperationResult> Handle(CreateReadMoreRequest request, CancellationToken cancellationToken)
        {
            List<string> errors = new List<string>();
            OperationResult op  = new OperationResult("Create Read More");
            if (await repo.HasReadMoreDuplicatedReadMoresByThisNameAndLink(request.ReadMoreCreateModel.LinkName
                , request.ReadMoreCreateModel.LinkText))
            {
                errors.Add("بیشتر بخوانیم با این مشخصات موجود است");
                return op.Failed("ثبت بیشتر بخوانیم ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var validator =new CreateReadMoreValidator();
            var validation = await validator.ValidateAsync(request.ReadMoreCreateModel);
            if(!validation.IsValid)
            {
                errors.Add(validation.Errors.ToString());
                return op.Failed("ثبت بیشتر بخوانیم ناموفق", HttpStatusCode.BadRequest, errors);
            }
            var readMore = mapper.Map<ReadMore>(request.ReadMoreCreateModel);
            return await repo.CreateAsync(readMore);
        }
    }
}
