using Microsoft.EntityFrameworkCore;
using SaleCore.Domain.Entities;
using SaleCore.Infrastructure.Persistences.Contexts;
using SaleCore.Infrastructure.Persistences.Interfaces;

namespace SaleCore.Infrastructure.Persistences.Repositories
{
    public class PurcharseDetailRepository : IPurcharseDetailRepository
    {
        private readonly SaleCoreContext _context;

        public PurcharseDetailRepository(SaleCoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PurcharseDetail>> GetPurcharseDetailByPurcharseId(int purcharseId)
        {
            var response = await _context.Products
                .AsNoTracking()
                .Join(_context.PurcharseDetails, p => p.Id, pd => pd.ProductId, (p, pd) => new { Product = p, PurcharseDetail = pd})
                .Where(x => x.PurcharseDetail.PurcharseId == purcharseId)
                .Select(x => new PurcharseDetail
                {
                    ProductId = x.Product.Id,
                    Product = new Product
                    {
                        Image = x.Product.Image,
                        Code = x.Product.Code,
                        Name = x.Product.Name
                    },
                    Quantity = x.PurcharseDetail.Quantity,
                    UnitPurcharsePrice = x.PurcharseDetail.UnitPurcharsePrice,
                    Total = x.PurcharseDetail.Total
                })
                .ToListAsync();

            return response;
        }
    }
}