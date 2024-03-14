namespace SaleCore.Application.Dtos.Invoice.Request
{
    public class InvoiceRequestDto
    {
        public int VoucherDocumentTypeId { get; set; }
        public string? VoucherNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public int SaleId { get; set; }
        public int ClientId { get; set; }
        public int StatePaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public ICollection<InvoiceDetailRequestDto> InvoiceDetails { get; set; } = null!;
    }
}