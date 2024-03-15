using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.Sale.Request;
using SaleCore.Application.Dtos.Sale.Response;

namespace SaleCore.Application.Interfaces
{
    public interface ISaleApplication
    {
        Task<BaseResponse<IEnumerable<SaleResponseDto>>> ListSales(BaseFiltersRequest filters);
        Task<BaseResponse<SaleByIdResponseDto>> SaleById(int SaleId);
        Task<BaseResponse<bool>> RegisterSale(SaleRequestDto requestDto);
        Task<BaseResponse<bool>> CancelSale(int saleId);
    }
}