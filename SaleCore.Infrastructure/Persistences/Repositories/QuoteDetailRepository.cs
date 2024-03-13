using Microsoft.EntityFrameworkCore;
using SaleCore.Domain.Entities;
using SaleCore.Infrastructure.Persistences.Contexts;
using SaleCore.Infrastructure.Persistences.Interfaces;

namespace SaleCore.Infrastructure.Persistences.Repositories
{
    public class QuoteDetailRepository : IQuoteDetailRepository
    {
        private readonly SaleCoreContext _context;

        public QuoteDetailRepository(SaleCoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<QuoteDetail>> GetQuoteDetailByQuoteId(int quoteId)
        {
            var response = await _context.Products
                .AsNoTracking()
                .Join(_context.QuoteDetails, p => p.Id, pd => pd.ProductId, (p, pd) => new { Product = p, QuoteDetail = pd })
                .Where(x => x.QuoteDetail.QuoteId == quoteId)
                .Select(x => new QuoteDetail
                {
                    ProductId = x.Product.Id,
                    Product = new Product
                    {
                        Image = x.Product.Image,
                        Code = x.Product.Code,
                        Name = x.Product.Name
                    },
                    Quantity = x.QuoteDetail.Quantity,
                    UnitSalePrice = x.QuoteDetail.UnitSalePrice,
                    Total = x.QuoteDetail.Total
                })
                .ToListAsync();

            return response;
        }
    }
}