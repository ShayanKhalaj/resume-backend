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
    public class RelatedArticleValidator:AbstractValidator<RelatedArticleDto>
    {
        public RelatedArticleValidator()
        {
            
            Include(new BaseValidator());

            RuleFor(x => x.RelationName)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(100).WithMessage("حداکثر 100 کاراکتر");
        }
    }
}
