namespace SaleCore.Application.Dtos.Quote.Response
{
    public class QuoteResponseDto
    {
        public int QuoteId { get; set; }
        public string? Client { get; set; }
        public decimal Discount { get; set; }
        public string? Vouchernumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string? StatePaid { get; set; }
        public DateTime DateOfSale { get; set; }
    }
}