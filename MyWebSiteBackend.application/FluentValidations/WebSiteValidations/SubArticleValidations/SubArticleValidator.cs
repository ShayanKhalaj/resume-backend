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
    public class SubArticleValidator:AbstractValidator<SubArticleDto>
    {
        public SubArticleValidator()
        {
            
            Include(new BaseValidator());

            RuleFor(x => x.ArticleID)
                .NotNull().WithMessage("*");
            
            RuleFor(x => x.Title)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(200).WithMessage("حداکثر 200 کاراکتر");
            
            RuleFor(x => x.Text)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(5000).WithMessage("حداکثر 5000 کاراکتر");
            
            RuleFor(x => x.AudioUrl)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر");
            
            RuleFor(x => x.AudioDescription)
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر");
            
            RuleFor(x => x.VideoUrl)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر");
            
            RuleFor(x => x.
                    VideoDescription)
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر");

        }
    }
}
