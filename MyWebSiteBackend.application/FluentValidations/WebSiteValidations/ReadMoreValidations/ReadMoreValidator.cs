using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ReadMoreValidations
{
    public class ReadMoreValidator:AbstractValidator<ReadMoreDto>
    {
        public ReadMoreValidator()
        {
            
            Include(new BaseValidator());

            RuleFor(x => x.SubArticleID)
                .NotNull().WithMessage("*");
            
            RuleFor(x => x.LinkText)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر وارد کنید");
            
            RuleFor(x => x.LinkName)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(200).WithMessage("حداکثر2000 کاراکتر وارد کنید");

        }
    }
}
