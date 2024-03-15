using AutoMapper;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.VoucherDocumentType.Response;
using SaleCore.Application.Interfaces;
using SaleCore.Infrastructure.Persistences.Interfaces;
using SaleCore.Utilities.Static;
using WatchDog;

namespace SaleCore.Application.Services
{
    public class VoucherDocumentTypeApplication : IVoucherDocumentTypeApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VoucherDocumentTypeApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<VoucherDocumentTypeResponseDto>>> ListVoucherDocumentTypes()
        {
            var response = new BaseResponse<IEnumerable<VoucherDocumentTypeResponseDto>>();

            try
            {
                var voucherDocumentTypes = await _unitOfWork.VoucherDocumentType.GetSelectAsync();

                if (voucherDocumentTypes is not null)
                {
                    response.Data = _mapper.Map<IEnumerable<VoucherDocumentTypeResponseDto>>(voucherDocumentTypes);
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