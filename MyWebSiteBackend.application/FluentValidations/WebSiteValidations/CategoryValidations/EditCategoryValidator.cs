﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Categories;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.CategoryValidations
{
    public class EditCategoryValidator:AbstractValidator<CategoryAddEditModel>
    {

        public EditCategoryValidator()
        {

            Include(new CategoryValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
