using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.SubArticles;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.SubArticleValidations
{
    public class EditSubArticleValidator:AbstractValidator<SubArticleCreateEditModel>
    {
        public EditSubArticleValidator()
        {
            
            Include(new SubArticleValidator());
            
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
