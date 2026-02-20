
using Cardinow.Application.Dtos.Resellers;
using FluentValidation;

namespace Cardinow.Application.Validators.Reseller;
public class UpdateResellerDomainDtoValidator
    : AbstractValidator<UpdateResellerDomainDto>
{
    public UpdateResellerDomainDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty();

        RuleFor(x => x.Domain)
            .NotEmpty()
            .MaximumLength(200)
            .When(x => x.Domain != null);
    }
}