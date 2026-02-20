using Cardinow.Application.Dtos.Users;
using FluentValidation;

namespace Cardinow.Application.Validators.User;
public class VerifyCodeDtoValidator : AbstractValidator<VerifyCodeDto>
{
    public VerifyCodeDtoValidator()
    {
        RuleFor(x => x.PhoneNumber)
            .Matches(@"^09\d{9}$")
            .WithMessage("Invalid Phone number format");

        RuleFor(x => x.Code)
            .NotEmpty()
            .Length(4, 6)
            .WithMessage("Entered Code is invalid");
    }
}