namespace SaleCore.Domain.Entities;

public partial class Invoice : BaseEntity
{
    public int ClientId { get; set; }

    public int SaleId { get; set; }

    public int VoucherDocumentTypeId { get; set; }

    public string? VoucherNumber { get; set; }

    public int StatePaid { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? PaidDate { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual Sale Sale { get; set; } = null!;

    public virtual VoucherDocumentType VoucherDocumentType { get; set; } = null!;
}