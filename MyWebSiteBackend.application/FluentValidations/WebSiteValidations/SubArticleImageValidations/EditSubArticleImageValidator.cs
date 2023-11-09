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
    public class EditSubArticleImageValidator:AbstractValidator<SubArticleImageCreateEditModel>
    {
        public EditSubArticleImageValidator()
        {
            
            Include(new SubArticleImageValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
