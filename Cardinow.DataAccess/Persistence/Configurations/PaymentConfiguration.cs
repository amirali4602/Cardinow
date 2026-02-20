using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cardinow.DataAccess.Persistence.Configurations;

public class PaymentConfiguration
    : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> entity)
    {
        
        entity.Property(x => x.Amount)
                .HasPrecision(18, 2);

        entity.Property(x => x.Authority)
                .IsRequired()
                .HasMaxLength(100);

        entity.HasIndex(x => x.Authority)
                .IsUnique();

        entity.HasOne(x => x.Order)
                .WithMany()
                .HasForeignKey(x => x.OrderId);

        entity.HasQueryFilter(x => !x.IsDeleted);
        
    }
}
