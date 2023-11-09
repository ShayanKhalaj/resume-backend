using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ReferenceValidations
{
    public class ReferenceValidator:AbstractValidator<ReferenceDto>
    {
        public ReferenceValidator()
        {
            
            Include(new BaseValidator());

            RuleFor(x => x.ArticleID)
                .NotNull().WithMessage("*");
            
            RuleFor(x => x.Name)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(100).WithMessage("حداکثر 100 کاراکتر وارد کنید");
            
            RuleFor(x => x.Text)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر وارد کنید");
            
            RuleFor(x => x.Link)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر وارد کنید");

        }
    }
}
