using Cardinow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cardinow.DataAccess.Persistence.Configurations;

public class ProfileConfiguration
    : IEntityTypeConfiguration<Profile>
{
    public void Configure(EntityTypeBuilder<Profile> entity)
    {
        
        entity.Property(x => x.BannerUrl)
                .HasMaxLength(500);

        entity.Property(x => x.LogoUrl)
                .HasMaxLength(500);

        entity.Property(x => x.VcfLink)
                .HasMaxLength(500);

        entity.Property(x => x.LinksJson)
                .HasColumnType("jsonb");

        entity.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<Profile>(x => x.UserId);

        entity.HasQueryFilter(x => !x.IsDeleted);
    }
}
