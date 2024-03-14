using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using SaleCore.Domain.Entities;
using SaleCore.Infrastructure.Persistences.Contexts;
using SaleCore.Infrastructure.Persistences.Interfaces;
using System.Data;

namespace SaleCore.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SaleCoreContext _context;
        public IGenericRepository<Category> _category = null!;
        public IGenericRepository<Client> _client = null!;
        public IGenericRepository<DocumentType> _documentType = null!;
        public IGenericRepository<Invoice> _invoice = null!;
        public IInvoiceDetailRepository _invoiceDetail = null!;
        public IGenericRepository<Product> _product = null!;
        public IProductStockRepository _productStock = null!;
        public IGenericRepository<Provider> _provider = null!;
        public IGenericRepository<Purcharse> _purcharse = null!;
        public IPurcharseDetailRepository _purcharseDetail = null!;
        public IGenericRepository<Quote> _quote = null!;
        public IQuoteDetailRepository _quoteDetail = null!;
        public IGenericRepository<Sale> _sale = null!;
        public ISaleDetailRepository _saleDetail = null!;
        public IGenericRepository<SubCategory> _subCategory = null!;
        public IUserRepository _user = null!;
        public IGenericRepository<VoucherDocumentType> _voucherDocumentType = null!;
        public IWarehouseRepository _warehouse = null!;

        public UnitOfWork(SaleCoreContext context, IConfiguration configuration)
        {
            _context = context;
        }

        public IGenericRepository<Category> Category => _category ?? new GenericRepository<Category>(_context);
        public IGenericRepository<Client> Client => _client ?? new GenericRepository<Client>(_context);
        public IGenericRepository<DocumentType> DocumentType => _documentType ?? new GenericRepository<DocumentType>(_context);
        public IGenericRepository<Invoice> Invoice => _invoice ?? new GenericRepository<Invoice>(_context);
        public IInvoiceDetailRepository InvoiceDetail => _invoiceDetail ?? new InvoiceDetailRepository(_context);
        public IGenericRepository<Product> Product => _product ?? new GenericRepository<Product>(_context);
        public IProductStockRepository ProductStock => _productStock ?? new ProductStockRepository(_context);
        public IGenericRepository<Provider> Provider => _provider ?? new GenericRepository<Provider>(_context);
        public IGenericRepository<Purcharse> Purcharse => _purcharse ?? new GenericRepository<Purcharse>(_context);
        public IPurcharseDetailRepository PurcharseDetail => _purcharseDetail ?? new PurcharseDetailRepository(_context);
        public IGenericRepository<Quote> Quote => _quote ?? new GenericRepository<Quote>(_context);
        public IQuoteDetailRepository QuoteDetail => _quoteDetail ?? new QuoteDetailRepository(_context);
        public IGenericRepository<Sale> Sale => _sale ?? new GenericRepository<Sale>(_context);
        public ISaleDetailRepository SaleDetail => _saleDetail ?? new SaleDetailRepository(_context);
        public IGenericRepository<SubCategory> SubCategory => _subCategory ?? new GenericRepository<SubCategory>(_context);
        public IUserRepository User => _user ?? new UserRepository(_context);
        public IGenericRepository<VoucherDocumentType> VoucherDocumentType => _voucherDocumentType ?? new GenericRepository<VoucherDocumentType>(_context);
        public IWarehouseRepository Warehouse => _warehouse ?? new WarehouseRepository(_context);

        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}