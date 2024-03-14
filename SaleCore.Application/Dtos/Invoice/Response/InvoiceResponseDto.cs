namespace SaleCore.Application.Dtos.Invoice.Response
{
    public class InvoiceResponseDto
    {
        public int InvoiceId { get; set; }
        public string? Client { get; set; }
        public string? Sale { get; set; }
        public string? Vouchernumber { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime DateOfInvoice { get; set; }
        public DateTime DatePaid { get; set; }
        public string? StatePaid { get; set; }
     }
}