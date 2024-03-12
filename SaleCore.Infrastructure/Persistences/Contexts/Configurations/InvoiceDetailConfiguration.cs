using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class InvoiceDetailConfiguration : IEntityTypeConfiguration<InvoiceDetail>
    {
        public void Configure(EntityTypeBuilder<InvoiceDetail> builder)
        {
            builder.HasKey(e => new { e.InvoiceId, e.ProductId }).HasName("PK__InvoiceD__1CD666D9DC0F905E");
            builder.ToTable("InvoiceDetail");

            builder.Property(e => e.InvoiceId).ValueGeneratedOnAdd();
            builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.UnitSalePrice).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceDe__Invoi__01142BA1");

            builder.HasOne(d => d.Product).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__InvoiceDe__Produ__02084FDA");
        }
    }
}