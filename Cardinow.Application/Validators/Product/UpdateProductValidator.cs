using Cardinow.Application.Dtos.Products;
using FluentValidation;

namespace Cardinow.Application.Validators.Product;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Price)
            .GreaterThan(0);

        RuleFor(x => x.DiscountPercent)
            .InclusiveBetween(0, 100)
            .When(x => x.DiscountPercent.HasValue);

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0);
    }
}