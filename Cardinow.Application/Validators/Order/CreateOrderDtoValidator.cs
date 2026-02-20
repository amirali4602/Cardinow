using Cardinow.Application.Dtos.Orders;
using FluentValidation;

namespace Cardinow.Application.Validators.Order;
public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
{
    public CreateOrderDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .NotEmpty();
    }
}