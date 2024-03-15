namespace SaleCore.Domain.Entities;

public partial class VoucherDocumentType : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}