using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Interfaces
{
    public interface ISaleDetailRepository
    {
        Task<IEnumerable<SaleDetail>> GetSaleDetailBySaleId(int saleId);
    }
}