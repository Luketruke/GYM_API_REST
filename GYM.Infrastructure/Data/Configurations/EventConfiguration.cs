using GYM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYM.Infrastructure.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable<Event>("Events");

            builder.HasKey(e => e.Id).HasName("PK__Events__3214EC0782B90DB7");

            builder.Property(e => e.StatusEvent).HasColumnName("EventStatus");

            builder.Property(e => e.StatusEventId).HasColumnName("Status");

            builder.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

            builder.Property(e => e.EventDate).HasColumnType("datetime");

            builder.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}
