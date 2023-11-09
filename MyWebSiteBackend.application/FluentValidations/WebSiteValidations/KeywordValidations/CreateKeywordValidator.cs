using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.Keywords;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.KeywordValidations
{
    public class CreateKeywordValidator:AbstractValidator<KeywordCreateEditModel>
    {

        public CreateKeywordValidator()
        {

            Include(new KeywordValidator());
        }
    }
}
