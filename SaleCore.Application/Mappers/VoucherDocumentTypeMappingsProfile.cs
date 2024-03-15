using AutoMapper;
using SaleCore.Application.Dtos.VoucherDocumentType.Response;
using SaleCore.Domain.Entities;

namespace SaleCore.Application.Mappers
{
    public class VoucherDocumentTypeMappingsProfile : Profile
    {
        public VoucherDocumentTypeMappingsProfile()
        {
            CreateMap<VoucherDocumentType, VoucherDocumentTypeResponseDto>()
                .ForMember(x => x.VoucherDocumentTypeId, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}