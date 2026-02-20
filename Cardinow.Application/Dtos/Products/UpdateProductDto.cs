namespace Cardinow.Application.Dtos.Products;

public class UpdateProductDto
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int? DiscountPercent { get; set; }

    public bool IsActive { get; set; } = true;

    // Specail Pricing for Reseller
    public decimal? DedicatedResellerPrice { get; set; }

    public int Stock { get; set; }

}