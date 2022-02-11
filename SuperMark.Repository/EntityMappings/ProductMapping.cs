using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SuperMark.Common.Model;


namespace SuperMark.Repository.EntityMappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("SMPPRO");

            builder.Property(p => p.Id)
                .HasColumnName("PROREG")
                .IsRequired();

            builder.Property(p => p.Code)
       .HasColumnName("PROCOD")
       .IsRequired();
            builder.Property(p => p.Name)
.HasColumnName("PRONOM")
.IsRequired();

            builder.Property(p => p.Description)
.HasColumnName("PRODES")
.IsRequired();


            builder.Property(p => p.Img)
.HasColumnName("PROIMG")
.IsRequired();


            builder.Property(p => p.Price)
.HasColumnName("PROPRE")
.IsRequired();


            builder.HasKey(x => x.Id);
        }
    }
}