using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cardinow.DataAccess.Persistence.Configurations;

public class ResellerConfiguration
     : IEntityTypeConfiguration<Reseller>
{
    public void Configure(EntityTypeBuilder<Reseller> entity)
    {
     
        entity.Property(x => x.Domain)
                .HasMaxLength(200);

        entity.Property(x => x.RenewalPlansJson)
                .HasColumnType("nvarchar(max)");

        entity.HasIndex(x => x.Domain)
                .IsUnique();

        entity.HasOne(r => r.User)
                .WithOne(u => u.Reseller)
                .HasForeignKey<Reseller>(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

        entity.HasQueryFilter(x => !x.IsDeleted);
     
    }
}
