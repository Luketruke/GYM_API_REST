using GYM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYM.Infrastructure.Data.Configurations
{
    public class FighterConfiguration : IEntityTypeConfiguration<Fighter>
    {
        public void Configure(EntityTypeBuilder<Fighter> builder)
        {
            builder.ToTable<Fighter>("Fighters");

            builder.HasKey(e => e.Id).HasName("PK__Fighters__3214EC07E61D4259");

            builder.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.FirstName).HasColumnName("Name")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.EventId);

            builder.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Status);
        }
    }
}
