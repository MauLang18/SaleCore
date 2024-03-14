namespace SaleCore.Application.Dtos.Sale.Response
{
    public class SaleResponseDto
    {
        public int SaleId { get; set; }
        public string? Client { get; set; }
        public string? Warehouse { get; set; }
        public string? Quote { get; set; }
        public string? Vouchernumber { get; set; }
        public decimal TotalAmount { get; set; }
        public string? StatePaid { get; set; }
        public DateTime DateOfSale { get; set; }
    }
}