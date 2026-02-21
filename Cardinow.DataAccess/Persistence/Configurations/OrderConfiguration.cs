using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Cardinow.DataAccess.Persistence.Configurations;
public class OrderConfiguration
    : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        

        entity.Property(x => x.ShippingCost)
              .HasPrecision(18, 2);

        entity.Property(x => x.Status)
              .HasConversion<string>();

        entity.Property(x => x.PackageType)
              .HasConversion<string>();

        entity.HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(o => o.Product)
            .WithMany(p => p.Orders)
            .HasForeignKey(o => o.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasQueryFilter(x => !x.IsDeleted);
    }
}