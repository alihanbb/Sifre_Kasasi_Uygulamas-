using AppEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppData.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()// auto increment
                .IsRequired();
            builder.Property(u => u.WebSiteName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.WebUserName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.WebPassword)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
