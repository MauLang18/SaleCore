using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Warehous__2608AFF9564CAD78");
            builder.Property(e => e.Id)
                .HasColumnName("WarehouseId");
            builder.ToTable("Warehouse");

            builder.Property(e => e.Name).HasMaxLength(25);
        }
    }
}