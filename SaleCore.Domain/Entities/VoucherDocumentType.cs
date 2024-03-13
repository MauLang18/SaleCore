namespace SaleCore.Domain.Entities;

public partial class VoucherDocumentType : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}