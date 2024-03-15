namespace SaleCore.Domain.Entities;

public partial class Sale : BaseEntity
{
    public int ClientId { get; set; }

    public int WarehouseId { get; set; }

    public int VoucherDocumentTypeId { get; set; }

    public string? VoucherNumber { get; set; }

    public decimal Iva { get; set; }

    public string Observation { get; set; } = null!;

    public decimal SubTotal { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual VoucherDocumentType VoucherDocumentType { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}