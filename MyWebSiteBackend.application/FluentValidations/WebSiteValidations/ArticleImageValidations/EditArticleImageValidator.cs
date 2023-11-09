using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ArticleImages;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ArticleImageValidations
{
    public class EditArticleImageValidator:AbstractValidator<ArticleImageCreateEditModel>
    {

        public EditArticleImageValidator()
        {

            Include(new ArticleImageValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
