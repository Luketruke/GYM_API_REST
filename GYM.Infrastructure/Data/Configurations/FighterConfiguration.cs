using GYM.Core.Entities;
using GYM.Core.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            builder.Property(e => e.Remarks)
               .HasMaxLength(255)
               .IsUnicode(false);

            builder.Property(e => e.Status);

            //////////////////Enumerators/////////////////
            builder.Property(e => e.Category)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<CategoryEnum>());

            builder.Property(e => e.Modality)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<ModalityEnum>());

            builder.Property(e => e.Gender)
                .HasMaxLength(30)
                .IsUnicode(false)
                .IsRequired()
                .HasConversion(new EnumToStringConverter<GenderEnum>());
            //////////////////////////////////////////////


            ////One-to-Many Relationship Configuration////
            builder.HasOne(f => f.Dojo)
                .WithMany(d => d.Fighters)
                .HasForeignKey(f => f.DojoId)
                .HasConstraintName("FK_Fighter_Dojo");

            builder.HasOne(f => f.Event)
                .WithMany(e => e.Fighters)
                .HasForeignKey(f => f.EventId)
                .HasConstraintName("FK_Fighter_Event");
            //////////////////////////////////////////////

            
        }
    }
}
