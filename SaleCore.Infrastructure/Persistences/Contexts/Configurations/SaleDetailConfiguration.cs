using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.HasKey(e => new { e.SaleId, e.ProductId }).HasName("PK__SaleDeta__D5A30F93D1015521");
            builder.ToTable("SaleDetail");

            builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.UnitSalePrice).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Product).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaleDetai__Produ__7D439ABD");

            builder.HasOne(d => d.Quote).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.QuoteId)
                .HasConstraintName("FK__SaleDetai__Quote__7C4F7684");

            builder.HasOne(d => d.Sale).WithMany(p => p.SaleDetails)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaleDetai__SaleI__7B5B524B");
        }
    }
}