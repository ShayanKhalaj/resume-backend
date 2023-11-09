using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MyWebSiteBackend.application.Contracts.WebSiteContracts;
using MyWebSiteBackend.application.Dtos.WebSiteDtos.ReadMores;

namespace MyWebSiteBackend.application.FluentValidations.WebSiteValidations.ReadMoreValidations
{
    public class EditReadMoreValidator:AbstractValidator<ReadMoreCreateEditModel>
    {
        public EditReadMoreValidator()
        {

            Include(new ReadMoreValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
