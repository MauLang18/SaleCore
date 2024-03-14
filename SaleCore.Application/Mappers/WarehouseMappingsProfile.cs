using AutoMapper;
using SaleCore.Application.Commons.Select.Response;
using SaleCore.Application.Dtos.Warehouse.Request;
using SaleCore.Application.Dtos.Warehouse.Response;
using SaleCore.Domain.Entities;
using SaleCore.Utilities.Static;

namespace SaleCore.Application.Mappers
{
    public class WarehouseMappingsProfile : Profile
    {
        public WarehouseMappingsProfile()
        {
            CreateMap<Warehouse, WarehouseResponseDto>()
               .ForMember(x => x.WarehouseId, x => x.MapFrom(y => y.Id))
               .ForMember(x => x.StateWarehouse, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
               .ReverseMap();

            CreateMap<Warehouse, SelectResponse>()
                .ForMember(x => x.Description, x => x.MapFrom(y => y.Name))
                .ReverseMap();

            CreateMap<Warehouse, WarehouseByIdResponseDto>()
                .ForMember(x => x.WarehouseId, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<WarehouseRequestDto, Warehouse>();
        }
    }
}