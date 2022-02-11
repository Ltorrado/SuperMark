using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMark.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMark.Repository.EntityMappings
{
 public   class ProfileMapping : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.ToTable("IDEPRO");

            builder.Property(p => p.Id)
                .HasColumnName("PROREG")
                .IsRequired();

            builder.Property(p => p.Description)
    .HasColumnName("PRODES")
    .IsRequired();

            builder.HasKey(x => x.Id);
        }
    }
}

