namespace SaleCore.Application.Dtos.Invoice.Request
{
    public class InvoiceDetailRequestDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitSalePrice { get; set; }
        public decimal Total { get; set; }
    }
}