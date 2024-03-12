using System;
using System.Collections.Generic;

namespace SaleCore.Domain.Entities;

public partial class Sale
{
    public int SaleId { get; set; }

    public int ClientId { get; set; }

    public int WarehouseId { get; set; }

    public int? QuoteId { get; set; }

    public int VoucherDocumentTypeId { get; set; }

    public string? VoucherNumber { get; set; }

    public decimal Iva { get; set; }

    public string Observation { get; set; } = null!;

    public decimal SubTotal { get; set; }

    public decimal TotalAmount { get; set; }

    public int StatePaid { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public int State { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual Quote? Quote { get; set; }

    public virtual ICollection<SaleDetail> SaleDetails { get; set; } = new List<SaleDetail>();

    public virtual VoucherDocumentType VoucherDocumentType { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
