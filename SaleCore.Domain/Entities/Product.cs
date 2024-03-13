﻿namespace SaleCore.Domain.Entities;

public partial class Product : BaseEntity
{
    public string? Code { get; set; }

    public string? Name { get; set; }

    public int? StockMin { get; set; }

    public int? StockMax { get; set; }

    public string? Image { get; set; }

    public int CategoryId { get; set; }

    public int SubCategoryId { get; set; }

    public decimal UnitSalePrice { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();

    public virtual ICollection<PurcharseDetail> PurcharseDetails { get; set; } = new List<PurcharseDetail>();

    public virtual ICollection<QuoteDetail> QuoteDetails { get; set; } = new List<QuoteDetail>();

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual SubCategory SubCategory { get; set; } = null!;
}