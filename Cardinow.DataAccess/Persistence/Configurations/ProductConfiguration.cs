using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cardinow.DataAccess.Persistence.Configurations;


public class ProductConfiguration
    : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> entity)
    {
        entity.Property(x => x.Name)
              .IsRequired()
              .HasMaxLength(200);

        entity.Property(x => x.Price)
              .HasPrecision(18, 2);

        entity.Property(x => x.DedicatedResellerPrice)
              .HasPrecision(18, 2);

        entity.HasIndex(x => x.Name);

        entity.HasQueryFilter(x => !x.IsDeleted);
    }
}