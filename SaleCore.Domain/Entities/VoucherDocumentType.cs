using System;
using System.Collections.Generic;

namespace SaleCore.Domain.Entities;

public partial class VoucherDocumentType
{
    public int VoucherDocumentTypeId { get; set; }

    public string? Name { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public int State { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Quote> Quotes { get; set; } = new List<Quote>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
