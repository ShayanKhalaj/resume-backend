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
    public class CreateRelatedArticleValidator:AbstractValidator<RelatedArticleCreateEditModel>
    {

        public CreateRelatedArticleValidator()
        {
            
            Include(new RelatedArticleValidator());
        }
    }
}
