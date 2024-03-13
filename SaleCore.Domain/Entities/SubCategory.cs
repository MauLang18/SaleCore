namespace SaleCore.Domain.Entities;

public partial class SubCategory : BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}