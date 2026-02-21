using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinow.DataAccess.Persistence.Configurations;

public class WalletTransactionConfiguration
    : IEntityTypeConfiguration<WalletTransaction>
{
    public void Configure(EntityTypeBuilder<WalletTransaction> entity)
    {
        
        entity.Property(x => x.Amount)
                .HasPrecision(18, 2);

        entity.Property(x => x.Type)
                .HasConversion<string>();

        entity.Property(x => x.Reason)
                .HasMaxLength(300);

        entity.HasOne(t => t.Wallet)
                .WithMany(w => w.Transactions)
                .HasForeignKey(t => t.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

        entity.HasQueryFilter(x => !x.IsDeleted);
    }
}
