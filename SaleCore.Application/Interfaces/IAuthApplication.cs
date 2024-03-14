using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.User.Request;

namespace SaleCore.Application.Interfaces
{
    public interface IAuthApplication
    {
        Task<BaseResponse<string>> Login(TokenRequestDto requestDto, string authType);
        Task<BaseResponse<string>> LoginWithGoogle(string credentials, string authType);
    }
}