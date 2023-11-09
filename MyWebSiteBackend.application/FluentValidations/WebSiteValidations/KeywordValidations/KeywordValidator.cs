using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.KeywordValidations
{
    public class KeywordValidator:AbstractValidator<KeywordDto>
    {

        public KeywordValidator()
        {
            
            Include(new BaseValidator());

            RuleFor(x => x.ArticleID)
                .NotNull().WithMessage("*")
                .GreaterThan(0).WithMessage("شناسه نامعتبر");
            
            RuleFor(x => x.Name)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(100).WithMessage("حداکثر 100 کاراکتر وارد کنید");
            
            RuleFor(x => x.Text)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(200).WithMessage("حداکثر 200 کاراکتر وارد کنید");

        }
    }
}
