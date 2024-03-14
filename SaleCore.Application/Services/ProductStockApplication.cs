using AutoMapper;
using SaleCore.Application.Commons.Bases.Response;
using SaleCore.Application.Dtos.ProductStock;
using SaleCore.Application.Interfaces;
using SaleCore.Infrastructure.Persistences.Interfaces;
using SaleCore.Utilities.Static;
using WatchDog;

namespace SaleCore.Application.Services
{
    public class ProductStockApplication : IProductStockApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductStockApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<ProductStockByWarehouseResponseDto>>>
            GetProductStockByWarehouseAsync(int productId)
        {
            var response = new BaseResponse<IEnumerable<ProductStockByWarehouseResponseDto>>();

            try
            {
                var productStockByWarehouse = await _unitOfWork
                    .ProductStock
                    .GetProductStockByWarehouse(productId);

                response.IsSuccess = true;
                response.Data = _mapper.Map<IEnumerable<ProductStockByWarehouseResponseDto>>
                    (productStockByWarehouse);
                response.Message = ReplyMessage.MESSAGE_QUERY;
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