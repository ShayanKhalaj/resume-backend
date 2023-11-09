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
    public class CreateArticleValidator:AbstractValidator<ArticleCreateEditModel>
    {

        public CreateArticleValidator()
        {

            Include(new ArticleValidator());
        }
    }
}
