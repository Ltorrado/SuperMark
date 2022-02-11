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
   public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("SMPVEN");

            builder.Property(p => p.Id)
                .HasColumnName("VENREG")
                .IsRequired();

            builder.Property(p => p.ProductId)
    .HasColumnName("VENPRO")
    .IsRequired();

            builder.Property(p => p.UserId)
.HasColumnName("VENUSU")
.IsRequired();
            builder.Property(p => p.Quantity)
.HasColumnName("VENCAN")
.IsRequired();
            builder.HasKey(x => x.Id);
        }
    }
}