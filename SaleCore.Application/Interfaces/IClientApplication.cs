using SaleCore.Application.Commons.Bases.Request;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Commons.Select.Response;
using SaleCore.Application.Dtos.Client.Request;
using SaleCore.Application.Dtos.Client.Response;

namespace SaleCore.Application.Interfaces
{
    public interface IClientApplication
    {
        Task<BaseResponse<IEnumerable<ClientResponseDto>>> ListClient(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<SelectResponse>>> ListSelectClients();
        Task<BaseResponse<ClientByIdResponseDto>> ClientById(int clientId);
        Task<BaseResponse<bool>> RegisterClient(ClientRequestDto requestDto);
        Task<BaseResponse<bool>> EditClient(int clientId, ClientRequestDto requestDto);
        Task<BaseResponse<bool>> RemoveClient(int clientId);
    }
}