namespace SaleCore.Domain.Entities;

public partial class Warehouse : BaseEntity
{
    public string? Name { get; set; }

    public virtual ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();

    public virtual ICollection<Purcharse> Purcharses { get; set; } = new List<Purcharse>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}