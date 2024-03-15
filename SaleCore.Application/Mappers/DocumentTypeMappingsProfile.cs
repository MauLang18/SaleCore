using AutoMapper;
using SaleCore.Application.Dtos.DocumentType.Response;
using SaleCore.Domain.Entities;

namespace SaleCore.Application.Mappers
{
    public class DocumentTypeMappingsProfile : Profile
    {
        public DocumentTypeMappingsProfile() 
        {
            CreateMap<DocumentType, DocumentTypeResponseDto>()
                .ForMember(x => x.DocumentTypeId, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}