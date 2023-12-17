using GYM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYM.Infrastructure.Data.Configurations
{
    public class FightConfiguration : IEntityTypeConfiguration<Fight>
    {
        public void Configure(EntityTypeBuilder<Fight> builder)
        {
            builder.ToTable<Fight>("Fights");

            builder.HasKey(e => e.Id).HasName("PK__Fights__3214EC07F3517644");

            builder.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(e => e.EventId);

            builder.Property(e => e.Status);
        }
    }
}
