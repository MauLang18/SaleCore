using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Interfaces
{
    public interface IQuoteDetailRepository
    {
        Task<IEnumerable<QuoteDetail>> GetQuoteDetailByQuoteId(int quoteId);
    }
}