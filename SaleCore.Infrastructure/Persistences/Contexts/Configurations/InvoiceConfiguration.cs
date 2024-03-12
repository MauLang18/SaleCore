using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(e => e.InvoiceId).HasName("PK__Invoice__D796AAB5B1E0ED8A");
            builder.ToTable("Invoice");

            builder.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Client).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__ClientI__7F2BE32F");

            builder.HasOne(d => d.Sale).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__SaleId__7E37BEF6");

            builder.HasOne(d => d.VoucherDocumentType).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.VoucherDocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Invoice__Voucher__00200768");
        }
    }
}