using System;
using System.Collections.Generic;

namespace SaleCore.Domain.Entities;

public partial class Quote
{
    public int QuoteId { get; set; }

    public int ClientId { get; set; }

    public int VoucherDocumentTypeId { get; set; }

    public string? VoucherNumber { get; set; }

    public decimal? Discount { get; set; }

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

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual VoucherDocumentType VoucherDocumentType { get; set; } = null!;
}
