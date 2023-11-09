using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos;

namespace MyWebSiteBackend.application.FluentValidations
{
    public class BaseValidator:AbstractValidator<BaseDto>
    {
        public BaseValidator()
        {


            RuleFor(x => x.CreatedBy)
                .MaximumLength(100).WithMessage("حد اکثر 100 کاراکتر وارد کنید");

            RuleFor(x => x.ModifiedBy)
                .MaximumLength(100).WithMessage("حد اکثر 100 کاراکتر وارد کنید");

            RuleFor(x => x.ModifiedDate)
                .MaximumLength(30).WithMessage("حداکثر 30 کاراکتر وارد کنید");

            RuleFor(x => x.CreatedDate)
                .MaximumLength(30).WithMessage("حداکثر 30 کاراکتر وارد کنید");

            RuleFor(x => x.Description)
                .MaximumLength(30).WithMessage("حداکثر 500 کاراکتر وارد کنید");
        }

    }
}
