using System;
using System.Collections.Generic;

namespace SaleCore.Domain.Entities;

public partial class Purcharse
{
    public int PurcharseId { get; set; }

    public int ProviderId { get; set; }

    public int WarehouseId { get; set; }

    public decimal Iva { get; set; }

    public string Observation { get; set; } = null!;

    public decimal SubTotal { get; set; }

    public decimal TotalAmount { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public int State { get; set; }

    public virtual Provider Provider { get; set; } = null!;

    public virtual ICollection<PurcharseDetail> PurcharseDetails { get; set; } = new List<PurcharseDetail>();

    public virtual Warehouse Warehouse { get; set; } = null!;
}
