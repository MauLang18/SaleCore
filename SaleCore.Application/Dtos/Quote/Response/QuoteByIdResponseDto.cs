namespace SaleCore.Application.Dtos.Quote.Response
{
    public class QuoteByIdResponseDto
    {
        public int QuoteId { get; set; }
        public string? VoucherNumber { get; set; }
        public string? Observation { get; set; }
        public decimal Discount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalAmount { get; set; }
        public int ClientId { get; set; }
        public int VoucherDocumentTypeId { get; set; }
        public DateTime DateOfSale { get; set; }
        public int StatePaid { get; set; }
        public ICollection<QuoteDetailByIdResponseDto> QuoteDetails { get; set; } = null!;
    }
}