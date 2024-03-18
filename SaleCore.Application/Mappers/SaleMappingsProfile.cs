using AutoMapper;
using SaleCore.Application.Dtos.Sale.Request;
using SaleCore.Application.Dtos.Sale.Response;
using SaleCore.Domain.Entities;

namespace SaleCore.Application.Mappers
{
    public class SaleMappingsProfile : Profile
    {
        public SaleMappingsProfile()
        {
            CreateMap<Sale, SaleResponseDto>()
                .ForMember(x => x.SaleId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Client, x => x.MapFrom(y => y.Client!.Name))
                .ForMember(x => x.Warehouse, x => x.MapFrom(y => y.Warehouse.Name))
                .ForMember(x => x.DateOfSale, x => x.MapFrom(y => y.AuditCreateDate))
                .ReverseMap();

            CreateMap<Sale, SaleByIdResponseDto>()
                 .ForMember(x => x.SaleId, x => x.MapFrom(y => y.Id))
                 .ForMember(x => x.DateOfSale, x => x.MapFrom(y => y.AuditCreateDate))
                 .ForMember(x => x.ClientId, x => x.MapFrom(y => y.ClientId))
                 .ForMember(x => x.ClientName, x => x.MapFrom(y => y.Client.Name))
                 .ForMember(x => x.ClientAddress, x => x.MapFrom(y => y.Client.Address))
                 .ForMember(x => x.ClientPhone, x => x.MapFrom(y => y.Client.Phone))
                 .ForMember(x => x.ClientEmail, x => x.MapFrom(y => y.Client.Email))
                 .ReverseMap();

            CreateMap<SaleDetail, SaleDetailByIdResponseDto>()
                .ForMember(x => x.ProductId, x => x.MapFrom(y => y.ProductId))
                .ForMember(x => x.Image, x => x.MapFrom(y => y.Product.Image))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Product.Code))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Product.Name))
                .ForMember(x => x.TotalAmount, x => x.MapFrom(y => y.Total))
                .ReverseMap();

            CreateMap<SaleRequestDto, Sale>();
            CreateMap<SaleDetailRequestDto, SaleDetail>();
        }
    }
}