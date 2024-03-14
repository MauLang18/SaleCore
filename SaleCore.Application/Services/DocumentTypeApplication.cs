using AutoMapper;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.DocumentType.Response;
using SaleCore.Application.Interfaces;
using SaleCore.Infrastructure.Persistences.Interfaces;
using SaleCore.Utilities.Static;
using WatchDog;

namespace SaleCore.Application.Services
{
    public class DocumentTypeApplication : IDocumentTypeApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DocumentTypeApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<DocumentTypeResponseDto>>> ListDocumentTypes()
        {
            var response = new BaseResponse<IEnumerable<DocumentTypeResponseDto>>();

            try
            {
                var documentTypes = await _unitOfWork.DocumentType.GetSelectAsync();

                if (documentTypes is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<DocumentTypeResponseDto>>(documentTypes);
                    response.IsSuccess = true;
                    response.Message = ReplyMessage.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_EXCEPTION;
                WatchLogger.Log(ex.Message);
            }

            return response;
        }
    }
}