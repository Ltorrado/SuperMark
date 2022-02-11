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
  public  class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("IDEUSU");

            builder.Property(p => p.Id)
                .HasColumnName("USUREG")
                .IsRequired();
            builder.Property(p => p.Name)
               .HasColumnName("USUNOM")
               .IsRequired();
            builder.Property(p => p.PassWord)
            .HasColumnName("USUPAS")
            .IsRequired();
            builder.Property(p => p.Profile)
        .HasColumnName("USUPRO")
        .IsRequired();
            builder.Property(p => p.UserLogin)
.HasColumnName("USUUSU")
.IsRequired();
 
            builder.HasKey(x => x.Id);
        }
    }
}