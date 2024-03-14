using AutoMapper;
using SaleCore.Application.Dtos.Invoice.Request;
using SaleCore.Application.Dtos.Invoice.Response;
using SaleCore.Domain.Entities;
using SaleCore.Utilities.Static;

namespace SaleCore.Application.Mappers
{
    public class InvoiceMappingsProfile : Profile
    {
        public InvoiceMappingsProfile()
        {
            CreateMap<Invoice, InvoiceResponseDto>()
                .ForMember(x => x.InvoiceId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.Client, x => x.MapFrom(y => y.Client!.Name))
                .ForMember(x => x.Sale, x => x.MapFrom(y => y.Sale!.VoucherNumber))
                .ForMember(x => x.StatePaid, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Pagada" : "Pendiente"))
                .ForMember(x => x.DateOfInvoice, x => x.MapFrom(y => y.AuditCreateDate))
                .ReverseMap();

            CreateMap<Invoice, InvoiceByIdResponseDto>()
                 .ForMember(x => x.InvoiceId, x => x.MapFrom(y => y.Id))
                 .ReverseMap();

            CreateMap<InvoiceDetail, InvoiceDetailByIdResponseDto>()
                .ForMember(x => x.ProductId, x => x.MapFrom(y => y.ProductId))
                .ForMember(x => x.Image, x => x.MapFrom(y => y.Product.Image))
                .ForMember(x => x.Code, x => x.MapFrom(y => y.Product.Code))
                .ForMember(x => x.Name, x => x.MapFrom(y => y.Product.Name))
                .ForMember(x => x.TotalAmount, x => x.MapFrom(y => y.Total))
                .ReverseMap();

            CreateMap<InvoiceRequestDto, Invoice>();
            CreateMap<InvoiceDetailRequestDto, InvoiceDetail>();
        }
    }
}