using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class QuoteConfiguration : IEntityTypeConfiguration<Quote>
    {
        public void Configure(EntityTypeBuilder<Quote> builder)
        {
            builder.HasKey(e => e.QuoteId).HasName("PK__Quote__AF9688C159F0D61A");
            builder.ToTable("Quote");

            builder.Property(e => e.Discount).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Client).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quote__ClientId__74AE54BC");

            builder.HasOne(d => d.VoucherDocumentType).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.VoucherDocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Quote__VoucherDo__75A278F5");
        }
    }
}