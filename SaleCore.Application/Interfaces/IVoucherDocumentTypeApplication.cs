using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.VoucherDocumentType.Response;

namespace SaleCore.Application.Interfaces
{
    public interface IVoucherDocumentTypeApplication
    {
        Task<BaseResponse<IEnumerable<VoucherDocumentTypeResponseDto>>> ListVoucherDocumentTypes();
    }
}