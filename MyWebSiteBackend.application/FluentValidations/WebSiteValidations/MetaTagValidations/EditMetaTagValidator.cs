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
    public class EditMetaTagValidator:AbstractValidator<MetaTagCreateEditModel>
    {

        public EditMetaTagValidator()
        {
            
            Include(new MetaTagValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
