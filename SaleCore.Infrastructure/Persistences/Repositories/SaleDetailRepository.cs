using Microsoft.EntityFrameworkCore;
using SaleCore.Domain.Entities;
using SaleCore.Infrastructure.Persistences.Contexts;
using SaleCore.Infrastructure.Persistences.Interfaces;

namespace SaleCore.Infrastructure.Persistences.Repositories
{
    public class SaleDetailRepository : ISaleDetailRepository
    {
        private readonly SaleCoreContext _context;

        public SaleDetailRepository(SaleCoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SaleDetail>> GetSaleDetailBySaleId(int saleId)
        {
            var response = await _context.Products
                .AsNoTracking()
                .Join(_context.SaleDetails, p => p.Id, pd => pd.ProductId, (p, pd) => new { Product = p, SaleDetail = pd })
                .Where(x => x.SaleDetail.SaleId == saleId)
                .Select(x => new SaleDetail
                {
                    ProductId = x.Product.Id,
                    Product = new Product
                    {
                        Image = x.Product.Image,
                        Code = x.Product.Code,
                        Name = x.Product.Name
                    },
                    Quantity = x.SaleDetail.Quantity,
                    UnitSalePrice = x.SaleDetail.UnitSalePrice,
                    Total = x.SaleDetail.Total
                })
                .ToListAsync();

            return response;
        }
    }
}