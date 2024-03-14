namespace SaleCore.Application.Dtos.Invoice.Response
{
    public class InvoiceByIdResponseDto
    {
        public int InvoiceId { get; set; }
        public string? VoucherNumber { get; set; }
        public int StatePaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int ClientId { get; set; }
        public int SaleId { get; set; }
        public int VoucherDocumentTypeId { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public ICollection<InvoiceDetailByIdResponseDto> InvoiceDetails { get; set; } = null!;
    }
}