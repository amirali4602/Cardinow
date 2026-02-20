using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cardinow.DataAccess.Persistence.Configurations;

public class UserConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        
        entity.Property(x => x.PhoneNumber)
                .HasMaxLength(20);

        entity.Property(x => x.Email)
                .HasMaxLength(150);

        entity.Property(x => x.Role)
                .HasConversion<string>();

        entity.HasIndex(x => x.PhoneNumber)
                .IsUnique();

        entity.HasIndex(x => x.Email)
                .IsUnique();

        entity.HasQueryFilter(x => !x.IsDeleted);
        
    }
}
