using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Interfaces
{
    public interface IPurcharseDetailRepository
    {
        Task<IEnumerable<PurcharseDetail>> GetPurcharseDetailByPurcharseId(int purcharseId);
    }
}