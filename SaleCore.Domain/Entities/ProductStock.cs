namespace SaleCore.Domain.Entities;

public partial class ProductStock
{
    public int ProductId { get; set; }

    public int WarehouseId { get; set; }

    public int CurrentStock { get; set; }

    public decimal PurchasePrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}