using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class ProductStockConfiguration : IEntityTypeConfiguration<ProductStock>
    {
        public void Configure(EntityTypeBuilder<ProductStock> builder)
        {
            builder.HasKey(e => new { e.ProductId, e.WarehouseId }).HasName("PK__ProductS__366C4C32E97833E0");
            builder.ToTable("ProductStock");

            builder.Property(e => e.PurchasePrice).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Product).WithMany(p => p.ProductStocks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductSt__Produ__6EF57B66");

            builder.HasOne(d => d.Warehouse).WithMany(p => p.ProductStocks)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductSt__Wareh__6FE99F9F");
        }
    }
}