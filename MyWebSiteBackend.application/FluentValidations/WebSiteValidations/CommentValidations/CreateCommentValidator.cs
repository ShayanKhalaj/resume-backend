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
    public class CreateCommentValidator:AbstractValidator<CommentCreateEditModel>
    {

        public CreateCommentValidator()
        {
            Include(new CommentValidator());
        }
    }
}
