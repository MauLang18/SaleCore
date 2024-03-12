﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6CD0EB0AF0D");
            builder.ToTable("Product");

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            builder.Property(e => e.UnitSalePrice).HasColumnType("decimal(10, 2)");

            builder.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Categor__6B24EA82");

            builder.HasOne(d => d.SubCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__SubCate__6C190EBB");
        }
    }
}