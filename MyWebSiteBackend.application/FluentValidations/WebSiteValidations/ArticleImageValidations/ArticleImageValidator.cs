using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MyWebSiteBackend.application.Contracts;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;
using MyWebSiteBackend.domain.Models.WebSiteModels;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ArticleImageValidations
{
    public class ArticleImageValidator: AbstractValidator<ArticleImageDto>
    {

        public ArticleImageValidator()
        {

            Include(new BaseValidator());
            
            RuleFor(x => x.ArticleID)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull().WithMessage("*");
            
            RuleFor(x => x.alter)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر وارد کنید");
            
            RuleFor(x => x.ImageUrl)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(500).WithMessage("حداکثر 2000 کاراکتر وارد کنید");

        }

    }
}
