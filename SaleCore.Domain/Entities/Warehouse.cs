using System;
using System.Collections.Generic;

namespace SaleCore.Domain.Entities;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public string? Name { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public int State { get; set; }

    public virtual ICollection<ProductStock> ProductStocks { get; set; } = new List<ProductStock>();

    public virtual ICollection<Purcharse> Purcharses { get; set; } = new List<Purcharse>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
