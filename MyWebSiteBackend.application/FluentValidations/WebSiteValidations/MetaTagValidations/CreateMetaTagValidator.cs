using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.MetaTags;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.MetaTagValidations
{
    public class CreateMetaTagValidator:AbstractValidator<MetaTagCreateEditModel>
    {

        public CreateMetaTagValidator()
        {
            Include(new MetaTagValidator());
        }
    }
}
