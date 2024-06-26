﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class VoucherDocumentTypeConfiguration : IEntityTypeConfiguration<VoucherDocumentType>
    {
        public void Configure(EntityTypeBuilder<VoucherDocumentType> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__VoucherD__CD0B68F2E39021AF");
            builder.Property(e => e.Id)
                .HasColumnName("VoucherDocumentTypeId");

            builder.ToTable("VoucherDocumentType");

            builder.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        }
    }
}