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
    public class CreateCategoryValidator:AbstractValidator<CategoryAddEditModel>
    {

        public CreateCategoryValidator()
        {
            Include(new CategoryValidator());
        }
    }
}
