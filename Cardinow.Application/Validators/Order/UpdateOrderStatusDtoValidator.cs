
using Cardinow.Application.Dtos.Orders;
using FluentValidation;

namespace Cardinow.Application.Validators.Order;

public class UpdateOrderStatusDtoValidator : AbstractValidator<UpdateOrderStatusDto>
{
    public UpdateOrderStatusDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Invalid ID");

        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Invalid Status");
    }
}