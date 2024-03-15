using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__User__1788CC4C280696F8");
            builder.Property(e => e.Id)
                .HasColumnName("UserId");
            builder.ToTable("User");

            builder.Property(e => e.AuthType)
                .HasMaxLength(15)
                .IsUnicode(false);
            builder.Property(e => e.Email).IsUnicode(false);
            builder .Property(e => e.Password).IsUnicode(false);
            builder.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}