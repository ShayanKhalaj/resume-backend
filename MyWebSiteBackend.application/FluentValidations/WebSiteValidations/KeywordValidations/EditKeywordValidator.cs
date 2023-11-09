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
    public class EditKeywordValidator:AbstractValidator<KeywordCreateEditModel>
    {

        public EditKeywordValidator()
        {
            Include(new KeywordValidator());

            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("شناسه نامعتبر")
                .NotNull()
                .WithMessage("*");
        }
    }
}
