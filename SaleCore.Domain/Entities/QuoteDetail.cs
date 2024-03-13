namespace SaleCore.Domain.Entities;

public partial class QuoteDetail
{
    public int QuoteId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal Total { get; set; }

    public decimal UnitSalePrice { get; set; }

    public virtual Product Product { get; set; } = null!;
}