using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.References;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ReferenceValidations
{
    public class EditReferenceValidator:AbstractValidator<ReferenceCreateEditModel>
    {
        public EditReferenceValidator()
        {
            
            Include(new ReferenceValidator());


            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
