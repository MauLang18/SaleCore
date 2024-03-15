using SaleCore.Domain.Entities;
using System.Data;

namespace SaleCore.Infrastructure.Persistences.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Category> Category { get; }
        IGenericRepository<Client> Client { get; }
        IGenericRepository<DocumentType> DocumentType { get; }
        IGenericRepository<Product> Product { get; }
        IProductStockRepository ProductStock { get; }
        IGenericRepository<Provider> Provider { get; }
        IGenericRepository<Purcharse> Purcharse { get; }
        IPurcharseDetailRepository PurcharseDetail { get; }
        IGenericRepository<Sale> Sale { get; }
        ISaleDetailRepository SaleDetail { get; }
        IUserRepository User { get; }
        IGenericRepository<VoucherDocumentType> VoucherDocumentType { get; }
        IWarehouseRepository Warehouse { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        IDbTransaction BeginTransaction();
    }
}