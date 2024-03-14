using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.Purcharse.Request;
using SaleCore.Application.Dtos.Purcharse.Response;

namespace SaleCore.Application.Interfaces
{
    public interface IPurcharseApplication
    {
        Task<BaseResponse<IEnumerable<PurcharseResponseDto>>> ListPurcharses(BaseFiltersRequest filters);
        Task<BaseResponse<PurcharseByIdResponseDto>> PurcharseById(int purcharseId);
        Task<BaseResponse<bool>> RegisterPurcharse(PurcharseRequestDto requestDto);
        Task<BaseResponse<bool>> CancelPurcharse(int purcharseId);
    }
}