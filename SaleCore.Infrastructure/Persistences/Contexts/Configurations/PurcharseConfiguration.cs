using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class PurcharseConfiguration : IEntityTypeConfiguration<Purcharse>
    {
        public void Configure(EntityTypeBuilder<Purcharse> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Pucharse__1EE3C3FF970ED72A");
            builder.Property(e => e.Id)
                .HasColumnName("PurcharseId");
            builder.ToTable("Purcharse");

            builder.Property(e => e.Iva).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Provider).WithMany(p => p.Purcharses)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purcharse__Provi__70DDC3D8");

            builder.HasOne(d => d.Warehouse).WithMany(p => p.Purcharses)
                .HasForeignKey(d => d.WarehouseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Purcharse__Wareh__71D1E811");
        }
    }
}