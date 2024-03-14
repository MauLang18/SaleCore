namespace SaleCore.Application.Dtos.Quote.Response
{
    public class QuoteDetailByIdResponseDto
    {
        public int ProductId { get; set; }
        public string? Image { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public int Quantity { get; set; }
        public decimal UnitSalePrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}