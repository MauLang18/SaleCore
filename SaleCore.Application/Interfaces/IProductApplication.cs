using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.Product.Request;
using SaleCore.Application.Dtos.Product.Response;

namespace SaleCore.Application.Interfaces
{
    public interface IProductApplication
    {
        Task<BaseResponse<IEnumerable<ProductResponseDto>>> ListProducts(BaseFiltersRequest filters);
        Task<BaseResponse<ProductByIdResponseDto>> ProductById(int productId);
        Task<BaseResponse<bool>> RegisterProduct(ProductRequestDto requestDto);
        Task<BaseResponse<bool>> EditProduct(int productId, ProductRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveProduct(int productId);
    }
}