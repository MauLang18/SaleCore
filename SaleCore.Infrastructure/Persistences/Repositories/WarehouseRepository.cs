using SaleCore.Domain.Entities;
using SaleCore.Infrastructure.Persistences.Contexts;
using SaleCore.Infrastructure.Persistences.Interfaces;

namespace SaleCore.Infrastructure.Persistences.Repositories
{
    public class WarehouseRepository : GenericRepository<Warehouse>, IWarehouseRepository
    {
        private readonly SaleCoreContext _context;

        public WarehouseRepository(SaleCoreContext context) : base(context) 
        {
            _context = context;
        }
    }
}