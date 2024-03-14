using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Commons.Select.Response;
using SaleCore.Application.Dtos.Warehouse.Request;
using SaleCore.Application.Dtos.Warehouse.Response;

namespace SaleCore.Application.Interfaces
{
    public interface IWarehouseApplication
    {
        Task<BaseResponse<IEnumerable<WarehouseResponseDto>>> ListWarehouses(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<SelectResponse>>> ListSelectWarehouse();
        Task<BaseResponse<WarehouseByIdResponseDto>> WarehouseById(int warehouseId);
        Task<BaseResponse<bool>> RegisterWarehouse(WarehouseRequestDto requestDto);
        Task<BaseResponse<bool>> EditWarehouse(int warehouseId, WarehouseRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveWarehouse(int warehouseId);
    }
}