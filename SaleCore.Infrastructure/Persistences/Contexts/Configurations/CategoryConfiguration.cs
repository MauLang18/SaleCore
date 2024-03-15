using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Category__19093A0B1B66D1AA");
            builder.Property(e => e.Id)
                .HasColumnName("CategoryId");
            builder.ToTable("Category");

            builder.Property(e => e.Name).HasMaxLength(100);
        }
    }
}