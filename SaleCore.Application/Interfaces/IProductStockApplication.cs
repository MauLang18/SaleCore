using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.ProductStock;

namespace SaleCore.Application.Interfaces
{
    public interface IProductStockApplication
    {
        Task<BaseResponse<IEnumerable<ProductStockByWarehouseResponseDto>>>
            GetProductStockByWarehouseAsync(int productId);
    }
}