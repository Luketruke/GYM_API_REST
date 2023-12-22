using GYM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYM.Infrastructure.Data.Configurations
{
    public class LocalityConfiguration : IEntityTypeConfiguration<Locality>
    {
        public void Configure(EntityTypeBuilder<Locality> builder)
        {
            builder.ToTable<Locality>("Localities");

            builder.HasKey(e => e.Id).HasName("PK__Location__3214EC078BFAB5EA");

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Locality");

            builder.Property(e => e.ProvinceId)
                .HasColumnName("ProvinceId");

            builder.Property(e => e.Status).IsRequired();

            ////One-to-Many Relationship Configuration////
            builder.HasMany(l => l.Dojos)
                .WithOne(d => d.Locality)
                .HasForeignKey(d => d.LocalityId)
                .HasConstraintName("FK_Dojo_Locality");
            //////////////////////////////////////////////
        }
    }
}
