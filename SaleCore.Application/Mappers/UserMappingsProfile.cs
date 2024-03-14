using AutoMapper;
using SaleCore.Application.Dtos.User.Request;
using SaleCore.Domain.Entities;

namespace SaleCore.Application.Mappers
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<UserRequestDto, User>();
            CreateMap<TokenRequestDto, User>();
        }
    }
}