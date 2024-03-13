using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class QuoteDetailConfiguration : IEntityTypeConfiguration<QuoteDetail>
    {
        public void Configure(EntityTypeBuilder<QuoteDetail> builder)
        {
            builder.HasKey(e => new { e.QuoteId, e.ProductId }).HasName("PK__QuoteDet__64D644AD740DF2BA");
            builder.ToTable("QuoteDetail");

            builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.UnitSalePrice).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Product).WithMany(p => p.QuoteDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__QuoteDeta__Produ__76969D2E");
        }
    }
}