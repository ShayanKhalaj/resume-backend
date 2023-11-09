using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticleImages;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.SubArticleImageValidations
{
    public class SubArticleImageValidator:AbstractValidator<SubArticleImageDto>
    {
        public SubArticleImageValidator()
        {
            
            Include(new BaseValidator());

            RuleFor(x => x.SubArticleID)
                .NotNull().WithMessage("*");
            
            RuleFor(x => x.Alter)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر");
            
            RuleFor(x => x.ImageUrl)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر");
            
        }
    }
}
