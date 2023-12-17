using GYM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYM.Infrastructure.Data.Configurations
{
    public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.ToTable<Province>("Provinces");

            builder.HasKey(e => e.Id).HasName("PK__Province__3214EC07E8B641F9");

            builder.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Province");

            builder.HasMany(p => p.Dojos)
                .WithOne(d => d.Province)
                .HasForeignKey(d => d.ProvinceId)
                .HasConstraintName("FK_Dojo_Province");
        }
    }
}
