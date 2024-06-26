﻿namespace SaleCore.Domain.Entities;

public partial class Provider : BaseEntity
{
    public string? Name { get; set; }

    public int DocumentTypeId { get; set; }

    public string? DocumentNumber { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual ICollection<Purcharse> Purcharses { get; set; } = new List<Purcharse>();
}