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
    public class CreateArticleImageValidator:AbstractValidator<ArticleImageCreateEditModel>
    {

        public CreateArticleImageValidator()
        {
            Include(new ArticleImageValidator());
        }
    }
}
