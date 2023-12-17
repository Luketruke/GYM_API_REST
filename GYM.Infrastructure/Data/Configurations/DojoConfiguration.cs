using GYM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYM.Infrastructure.Data.Configurations
{
    public class DojoConfiguration : IEntityTypeConfiguration<Dojo>
    {
        public void Configure(EntityTypeBuilder<Dojo> builder)
        {
            builder.ToTable("Dojos");

            builder.HasKey(e => e.Id).HasName("PK__Dojos__3214EC07213874E3");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.DojoPhone)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.InstructorName)
                .HasMaxLength(80)
                .IsUnicode(false).HasColumnName("Instructor");

            builder.Property(e => e.InstructorPhone)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Address)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.Status);
        }
    }
}