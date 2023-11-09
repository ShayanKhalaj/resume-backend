using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.RelatedArticles;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.RelatedArticlesValidations
{
    public class EditRelatedArticleValidator:AbstractValidator<RelatedArticleCreateEditModel>
    {
        public EditRelatedArticleValidator()
        {
            
            Include(new RelatedArticleValidator());

            RuleFor(x => x.Id)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*");
        }
    }
}
