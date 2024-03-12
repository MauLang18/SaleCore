using System;
using System.Collections.Generic;

namespace SaleCore.Domain.Entities;

public partial class DocumentType
{
    public int DocumentTypeId { get; set; }

    public string? Code { get; set; }

    public string? Name { get; set; }

    public string? Abbreviation { get; set; }

    public int AuditCreateUser { get; set; }

    public DateTime AuditCreateDate { get; set; }

    public int? AuditUpdateUser { get; set; }

    public DateTime? AuditUpdateDate { get; set; }

    public int AuditDeleteUser { get; set; }

    public DateTime? AuditDeleteDate { get; set; }

    public int State { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<Provider> Providers { get; set; } = new List<Provider>();
}
