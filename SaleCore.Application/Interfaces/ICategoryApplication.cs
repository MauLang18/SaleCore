using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Commons.Select.Response;
using SaleCore.Application.Dtos.Category.Request;
using SaleCore.Application.Dtos.Category.Response;

namespace SaleCore.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<IEnumerable<CategoryResponseDto>>> ListCategories(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<SelectResponse>>> ListSelectCategories();
        Task<BaseResponse<CategoryResponseDto>> CategoryById(int categoryId);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveCategory(int categoryId);
    }
}