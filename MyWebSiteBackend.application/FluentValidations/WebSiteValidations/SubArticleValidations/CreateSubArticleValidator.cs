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
    public class CreateSubArticleValidator:AbstractValidator<SubArticleCreateEditModel>
    {
        public CreateSubArticleValidator()
        {
            
            Include(new SubArticleValidator());
        }
    }
}
