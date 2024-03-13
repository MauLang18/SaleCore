using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(e => e.SaleId).HasName("PK__Sale__1EE3C3FF970ED72A");
            builder.ToTable("Sale");

            builder.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Client).WithMany(p => p.Sales)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__ClientId__778AC167");

            builder.HasOne(d => d.Quote).WithMany(p => p.Sales)
                .HasForeignKey(d => d.QuoteId)
                .HasConstraintName("FK__Sale__QuoteId__787EE5A0");

            builder.HasOne(d => d.VoucherDocumentType).WithMany(p => p.Sales)
                .HasForeignKey(d => d.VoucherDocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__VoucherDoc__797309D9");

            builder.HasOne(d => d.Warehouse).WithMany(p => p.Sales)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sale__WarehouseI__7A672E12");
        }
    }
}