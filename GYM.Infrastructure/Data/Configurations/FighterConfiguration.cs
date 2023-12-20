using GYM.Core.Entities;
using GYM.Core.Enumerators;
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

            builder.Property(e => e.FirstName).HasColumnName("Name")
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.LastName)
                .HasMaxLength(25)
                .IsUnicode(false);

            builder.Property(e => e.Age)
                .IsRequired();

            builder.Property(e => e.NIC)
                .IsRequired();

            builder.Property(e => e.FightCount)
                .IsRequired();

            builder.Property(e => e.Height).IsRequired();

            builder.Property(e => e.Weight).HasColumnType("decimal(18, 2)");

            builder.Property(e => e.Category)
                 .HasMaxLength(30)
                 .IsUnicode(false)
                 .IsRequired()
                 .HasConversion(
                     x => x.ToString(),
                     x => (CategoryEnum)Enum.Parse(typeof(CategoryEnum), x)
                 );

            builder.Property(e => e.Modality)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired()
                .HasConversion(
                    x => x.ToString(),
                    x => (ModalityEnum)Enum.Parse(typeof(ModalityEnum), x)
                );

            builder.Property(e => e.Gender)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired()
                .HasConversion(
                    x => x.ToString(),
                    x => (GenderEnum)Enum.Parse(typeof(GenderEnum), x)
                );

            builder.HasOne(d => d.Dojo)
                .WithMany(f => f.Fighters)
                .HasForeignKey(d => d.DojoId)
                .HasConstraintName("FK_Fighter_Dojo");

            //builder.Property(e => e.EventId)
            //    .IsRequired();

            builder.HasOne(d => d.Event)
                .WithMany(f => f.Fighters)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_Fighter_Event");

            builder.Property(e => e.Remarks)
               .HasMaxLength(255)
               .IsUnicode(false);

            builder.Property(e => e.Status);
        }
    }
}
