namespace SaleCore.Application.Dtos.Quote.Request
{
    public class QuoteDetailRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitSalePrice { get; set; }
        public decimal Total { get; set; }
    }
}