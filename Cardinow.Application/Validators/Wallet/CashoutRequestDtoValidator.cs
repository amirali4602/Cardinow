using Cardinow.Application.Dtos.Wallets;
using FluentValidation;

namespace Cardinow.Application.Validators.Wallet;

public class CashoutRequestDtoValidator
  : AbstractValidator<CashoutRequestDto>
{
    public CashoutRequestDtoValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0)
            .WithMessage("Cashout Amount Should be more than zero");

        RuleFor(x => x.BankInfo)
            .NotEmpty()
            .MinimumLength(10)
            .WithMessage("Bank info is Invalid");
    }
}
