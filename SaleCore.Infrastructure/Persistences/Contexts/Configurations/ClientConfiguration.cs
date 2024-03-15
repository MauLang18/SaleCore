using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__Client__E67E1A24984AFFB1");
            builder.Property(e => e.Id)
                .HasColumnName("ClientId");
            builder.ToTable("Client");

            builder.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Phone)
                .HasMaxLength(20)
            .IsUnicode(false);

            builder.HasOne(d => d.DocumentType).WithMany(p => p.Clients)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Client__Document__6D0D32F4");
        }
    }
}