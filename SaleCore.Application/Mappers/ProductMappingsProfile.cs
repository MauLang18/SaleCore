using AutoMapper;
using SaleCore.Application.Dtos.Product.Request;
using SaleCore.Application.Dtos.Product.Response;
using SaleCore.Domain.Entities;
using SaleCore.Utilities.Static;

namespace SaleCore.Application.Mappers
{
    public class ProductMappingsProfile : Profile
    {
        public ProductMappingsProfile()
        {
            CreateMap<Product, ProductResponseDto>()
                .ForMember(x => x.ProductId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Category, x => x.MapFrom(y => y.Category.Name))
                .ForMember(x => x.StateProduct,
                    x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<Product, ProductByIdResponseDto>()
                .ForMember(x => x.ProductId, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<ProductRequestDto, Product>();
        }
    }
}