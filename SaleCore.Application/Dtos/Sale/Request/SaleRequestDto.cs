namespace SaleCore.Application.Dtos.Sale.Request
{
    public class SaleRequestDto
    {
        public int VoucherDocumentTypeId { get; set; }
        public string? VoucherNumber { get; set; }
        public string? Observation { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Iva { get; set; }
        public decimal TotalAmount { get; set; }
        public int SaleId { get; set; }
        public int ClientId { get; set; }
        public int WarehouseId { get; set; }
        public ICollection<SaleDetailRequestDto> SaleDetails { get; set; } = null!;
    }
}