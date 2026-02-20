using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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

        entity.HasOne(x => x.User)
              .WithMany()
              .HasForeignKey(x => x.UserId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(x => x.Product)
              .WithMany()
              .HasForeignKey(x => x.ProductId)
              .OnDelete(DeleteBehavior.Restrict);

        entity.HasQueryFilter(x => !x.IsDeleted);
    }
}