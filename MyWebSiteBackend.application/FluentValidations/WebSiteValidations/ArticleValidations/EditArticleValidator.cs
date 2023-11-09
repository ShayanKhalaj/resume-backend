using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Articles;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ArticleValidations
{
    public class EditArticleValidator:AbstractValidator<ArticleCreateEditModel>
    {

        public EditArticleValidator()
        {

            Include(new ArticleValidator());


            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
