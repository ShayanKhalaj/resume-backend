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
    public class EditCommentValidator:AbstractValidator<CommentCreateEditModel>
    {

        public EditCommentValidator()
        {

            Include(new CommentValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
