
using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cardinow.DataAccess.Persistence.Configurations;

internal class LogConfiguration 
    : IEntityTypeConfiguration<Log>
{
    public void Configure(EntityTypeBuilder<Log> entity)
    {
        
            entity.Property(x => x.Action)
                  .HasConversion<string>();

            entity.Property(x => x.Details)
                  .HasMaxLength(1000);

            entity.Property(x => x.IpAddress)
                  .HasMaxLength(50);

            entity.HasIndex(x => x.Timestamp);

            entity.HasOne(l => l.User)
                    .WithMany(u => u.Logs)
                    .HasForeignKey(l => l.UserId)
                    .OnDelete(DeleteBehavior.SetNull);

    }
}
