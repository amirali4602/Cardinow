namespace Cardinow.Application.Validators.Product;

using Cardinow.Application.Dtos.Products;
using FluentValidation;

public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name Of Product is Required")
            .MaximumLength(200);

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price should be more than zero");

        RuleFor(x => x.DiscountPercent)
            .InclusiveBetween(0, 100)
            .When(x => x.DiscountPercent.HasValue);

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0);
    }
}