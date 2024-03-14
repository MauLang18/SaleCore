using AutoMapper;
using SaleCore.Application.Dtos.Quote.Request;
using SaleCore.Application.Dtos.Quote.Response;
using SaleCore.Domain.Entities;
using SaleCore.Utilities.Static;

namespace SaleCore.Application.Mappers
{
    public class QuoteMappingsProfile : Profile
    {
        public QuoteMappingsProfile()
        {
            CreateMap<Quote, QuoteResponseDto>()
                .ForMember(x => x.QuoteId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Client, x => x.MapFrom(y => y.Client!.Name))
                .ForMember(x => x.StatePaid, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Pagada" : "Pendiente"))
                .ForMember(x => x.DateOfSale, x => x.MapFrom(y => y.AuditCreateDate))
                .ReverseMap();

            CreateMap<Quote, QuoteByIdResponseDto>()
                 .ForMember(x => x.QuoteId, x => x.MapFrom(y => y.Id))
                 .ReverseMap();

            CreateMap<QuoteDetail, QuoteDetailByIdResponseDto>()
                .ForMember(x => x.ProductId, x => x.MapFrom(y => y.ProductId))
                .ForMember(x => x.Image, x => x.MapFrom(y => y.Product.Image))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Product.Code))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Product.Name))
                .ForMember(x => x.TotalAmount, x => x.MapFrom(y => y.Total))
                .ReverseMap();

            CreateMap<QuoteRequestDto, Quote>();
            CreateMap<QuoteDetailRequestDto, QuoteDetail>();
        }
    }
}