using Microsoft.EntityFrameworkCore;
using SaleCore.Domain.Entities;
using SaleCore.Infrastructure.Persistences.Contexts;
using SaleCore.Infrastructure.Persistences.Interfaces;

namespace SaleCore.Infrastructure.Persistences.Repositories
{
    public class InvoiceDetailRepository : IInvoiceDetailRepository
    {
        private readonly SaleCoreContext _context;

        public InvoiceDetailRepository(SaleCoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceDetail>> GetInvoiceDetailByInvoiceId(int invoiceId)
        {
            var response = await _context.Products
                .AsNoTracking()
                .Join(_context.InvoiceDetails, p => p.Id, pd => pd.ProductId, (p, id) => new { Product = p, InvoiceDetail = id })
                .Where(x => x.InvoiceDetail.InvoiceId == invoiceId)
                .Select(x => new InvoiceDetail
                {
                    ProductId = x.Product.Id,
                    Product = new Product
                    {
                        Image = x.Product.Image,
                        Code = x.Product.Code,
                        Name = x.Product.Name
                    },
                    Quantity = x.InvoiceDetail.Quantity,
                    UnitSalePrice = x.InvoiceDetail.UnitSalePrice,
                    Total = x.InvoiceDetail.Total
                })
                .ToListAsync();

            return response;
        }
    }
}