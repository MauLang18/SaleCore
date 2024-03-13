namespace SaleCore.Domain.Entities;

public partial class SaleDetail
{
    public int SaleId { get; set; }

    public int? QuoteId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Total { get; set; }

    public decimal UnitSalePrice { get; set; }

    public int State { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Quote? Quote { get; set; }

    public virtual Sale Sale { get; set; } = null!;
}