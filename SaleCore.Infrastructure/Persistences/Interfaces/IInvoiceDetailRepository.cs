using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Interfaces
{
    public interface IInvoiceDetailRepository
    {
        Task<IEnumerable<InvoiceDetail>> GetInvoiceDetailByInvoiceId(int invoiceId);
    }
}