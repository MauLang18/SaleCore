namespace SaleCore.Application.Dtos.VoucherDocumentType.Response
{
    public class VoucherDocumentTypeResponseDto
    {
        public int VoucherDocumentTypeId { get; set; }
        public string? Name { get; set; }
        public DateTime AuditCreateDate { get; set; }
        public int State { get; set; }
        public string? StateVoucherDocumentType { get; set; }
    }
}