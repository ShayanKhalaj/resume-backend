using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.MetaTagValidations
{
    public class MetaTagValidator:AbstractValidator<MetaTagDto>
    {

        public MetaTagValidator()
        {
            
            Include(new BaseValidator());

            RuleFor(x => x.ArticleID)
                .NotNull().WithMessage("*");
            
            RuleFor(x => x.TagName)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(100).WithMessage("حداکثر 100 کاراکتر وارد کنید");
            
            RuleFor(x => x.Tag)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر وارد کنید");

        }
            
    }
}
