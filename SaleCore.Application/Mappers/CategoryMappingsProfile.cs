using AutoMapper;
using SaleCore.Application.Commons.Select.Response;
using SaleCore.Application.Dtos.Category.Request;
using SaleCore.Application.Dtos.Category.Response;
using SaleCore.Domain.Entities;
using SaleCore.Utilities.Static;

namespace SaleCore.Application.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile()
        {
            CreateMap<Category, CategoryResponseDto>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<CategoryRequestDto, Category>();

            CreateMap<Category, SelectResponse>()
                .ForMember(x => x.Description, x => x.MapFrom(y => y.Name))
                .ReverseMap();
        }
    }
}