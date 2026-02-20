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
                .HasColumnType("jsonb");

        entity.HasIndex(x => x.Domain)
                .IsUnique();

        entity.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);

        entity.HasQueryFilter(x => !x.IsDeleted);
     
    }
}
