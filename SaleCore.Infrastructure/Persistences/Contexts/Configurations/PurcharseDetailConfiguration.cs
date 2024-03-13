using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class PurcharseDetailConfiguration : IEntityTypeConfiguration<PurcharseDetail>
    {
        public void Configure(EntityTypeBuilder<PurcharseDetail> builder)
        {
            builder.HasKey(e => new { e.PurcharseId, e.ProductId }).HasName("PK__Purchars__62CCAB2760589CAC");
            builder.ToTable("PurcharseDetail");

            builder.Property(e => e.Total).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.UnitPurcharsePrice).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Product).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purcharse__Produ__73BA3083");

            builder.HasOne(d => d.Purcharse).WithMany(p => p.PurcharseDetails)
                .HasForeignKey(d => d.PurcharseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purcharse__Purch__72C60C4A");
        }
    }
}