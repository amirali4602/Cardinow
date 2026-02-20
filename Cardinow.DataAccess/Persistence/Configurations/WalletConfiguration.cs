using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cardinow.DataAccess.Persistence.Configurations;

public class WalletConfiguration
    : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> entity)
    {
        
        entity.Property(x => x.Balance)
                .HasPrecision(18, 2);

        entity.Property(x => x.TotalSales)
                .HasPrecision(18, 2);

        entity.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Wallet>(x => x.UserId);

        entity.HasQueryFilter(x => !x.IsDeleted);
    }
}
