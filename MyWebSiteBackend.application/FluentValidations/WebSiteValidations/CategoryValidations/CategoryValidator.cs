using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.CategoryValidations
{
    public class CategoryValidator:AbstractValidator<CategoryDto>
    {

        public CategoryValidator()
        {

            Include(new BaseValidator());

            RuleFor(x => x.ImageUrl)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر وارد کنید");
            
            RuleFor(x => x.CategoryName)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(200).WithMessage("حداکثر 200 کاراکتر وارد کنید");
            
            RuleFor(x => x.ImageAlter)
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر وارد کنید");
        }

    }
}
