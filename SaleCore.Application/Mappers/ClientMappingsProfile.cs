using AutoMapper;
using SaleCore.Application.Commons.Select.Response;
using SaleCore.Application.Dtos.Client.Request;
using SaleCore.Application.Dtos.Client.Response;
using SaleCore.Domain.Entities;
using SaleCore.Utilities.Static;

namespace SaleCore.Application.Mappers
{
    public class ClientMappingsProfile : Profile
    {
        public ClientMappingsProfile()
        {
            CreateMap<Client, ClientResponseDto>()
                .ForMember(x => x.ClientId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.DocumentType, x => x.MapFrom(y => y.DocumentType.Abbreviation))
                .ForMember(x => x.StateClient,
                    x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<Client, SelectResponse>()
                .ForMember(x => x.Description, x => x.MapFrom(y => y.Name))
                .ReverseMap();

            CreateMap<Client, ClientByIdResponseDto>()
                .ForMember(x => x.ClientId, x => x.MapFrom(y => y.Id))
                .ReverseMap();

            CreateMap<ClientRequestDto, Client>();
        }
    }
}