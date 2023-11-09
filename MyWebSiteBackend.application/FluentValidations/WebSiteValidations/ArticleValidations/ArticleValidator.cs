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
    public class ArticleValidator : AbstractValidator<ArticleDto>
    {

        public ArticleValidator()
        {

            Include(new BaseValidator());

            RuleFor(x => x.Title)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(200).WithMessage("حداکثر 200 کاراکتر وارد کنید");
            
            RuleFor(x => x.Text)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(500).WithMessage("حداکثر 500 کاراکتر وارد کنید");
            
            RuleFor(x => x.CategoryID)
                .NotNull().WithMessage("*")
                .GreaterThan(0).WithMessage("شناسه نا معتبر");
            
            RuleFor(x => x.AudioUrl)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر وارد کنید");
            
            RuleFor(x => x.AudioDescription)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر وارد کنید");
            
            RuleFor(x => x.VideoUrl)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر وارد کنید");
            
            RuleFor(x => x.VideoDescription)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر وارد کنید");

        }
    }
}
