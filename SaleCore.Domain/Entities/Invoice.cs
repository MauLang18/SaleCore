using System;
using System.Collections.Generic;

namespace SaleCore.Domain.Entities;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int ClientId { get; set; }

    public int SaleId { get; set; }

    public int VoucherDocumentTypeId { get; set; }

    public string? VoucherNumber { get; set; }

    public int StatePaid { get; set; }

    public decimal TotalAmount { get; set; }

    public DateTime? PaidDate { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public int State { get; set; }

    public virtual Client Client { get; set; } = null!;

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();

    public virtual Sale Sale { get; set; } = null!;

    public virtual VoucherDocumentType VoucherDocumentType { get; set; } = null!;
}
