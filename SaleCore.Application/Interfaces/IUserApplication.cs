using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.User.Request;

namespace SaleCore.Application.Interfaces
{
    public interface IUserApplication
    {
        Task<BaseResponse<bool>> RegisterUser(UserRequestDto requestDto);
    }
}