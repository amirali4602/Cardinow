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

        entity.Property(x => x.CashedOut)
                .HasPrecision(18, 2);

        entity.HasOne(w => w.User)
                .WithOne(u => u.Wallet)
                .HasForeignKey<Wallet>(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        entity.HasQueryFilter(x => !x.IsDeleted);
    }
}
