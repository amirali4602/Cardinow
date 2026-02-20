using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinow.Domain.Entities;
public class Product : BaseEntity
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public int? DiscountPercent { get; set; }

    public bool IsActive { get; set; } = true;

    // Specail Pricing for Reseller
    public decimal? DedicatedResellerPrice { get; set; }

    public int Stock { get; set; }

    public ICollection<Order> Orders { get; set; }
}
