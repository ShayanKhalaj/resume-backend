using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Comments;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.CommentValidations
{
    public class CommentValidator:AbstractValidator<CommentDto>
    {

        public CommentValidator()
        {

            Include(new BaseValidator());
            
            RuleFor(x => x.Name)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(100).WithMessage("حداکثر 100 کاراکتر");
            
            RuleFor(x => x.Email)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(300).WithMessage("حداکثر 300 کاراکتر")
                .EmailAddress().WithMessage("فرمت ایمیل صحیح نمیباشد");
            
            RuleFor(x => x.Text)
                .NotNull().WithMessage("*")
                .NotEmpty().WithMessage("*")
                .MaximumLength(100).WithMessage("حداکثر 100 کاراکتر");
            
            RuleFor(x => x.Answer)
                .MaximumLength(2000).WithMessage("حداکثر 2000 کاراکتر");
            
        }
        
    }
}
