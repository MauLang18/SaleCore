using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.DocumentType.Response;

namespace SaleCore.Application.Interfaces
{
    public interface IDocumentTypeApplication
    {
        Task<BaseResponse<IEnumerable<DocumentTypeResponseDto>>> ListDocumentTypes();
    }
}