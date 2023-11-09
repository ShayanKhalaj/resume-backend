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
    public class CreateReferenceValidator:AbstractValidator<ReferenceCreateEditModel>
    {
        public CreateReferenceValidator()
        {
            Include(new ReferenceValidator());
        }
    }
}
