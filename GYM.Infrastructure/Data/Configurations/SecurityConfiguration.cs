using GYM.Core.Entities;
using GYM.Core.Enumerators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GYM.Infrastructure.Data.Configurations
{
    public class SecurityConfiguration : IEntityTypeConfiguration<Security>
    {
        public void Configure(EntityTypeBuilder<Security> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id).HasName("PK__Users__3214EC070A76A55D");

            builder.Property(e => e.User)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.UserName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(e => e.DojoId)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();

            //////////////////Enumerators/////////////////
            builder.Property(e => e.Role)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsRequired()
                .HasConversion(
                    x => x.ToString(),
                    x => (UserTypeEnum)Enum.Parse(typeof(UserTypeEnum), x));
            //////////////////////////////////////////////
        }
    }
}
