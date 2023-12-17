//using GYM.Core.Entities;
//using GYM.Core.Enumerators;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace GYM.Infrastructure.Data.Configurations
//{
//    public class UserConfiguration : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {
//            builder.ToTable<User>("Users");

//            builder.HasKey(e => e.Id).HasName("PK__Users__3214EC070A76A55D");

//            builder.Property(e => e.Password)
//                .HasMaxLength(40)
//                .IsUnicode(false).IsRequired();

//            builder.Property(e => e.UserName)
//                .HasMaxLength(40)
//                .IsUnicode(false).IsRequired();

//            builder.Property(e => e.Role)
//                .HasMaxLength(40)
//                .IsUnicode(false).HasConversion(
//                x => x.ToString(),
//                x => (UserType)Enum.Parse(typeof(UserType), x)
//                );

//            builder.Property(e => e.Status);
//        }
//    }
//}
