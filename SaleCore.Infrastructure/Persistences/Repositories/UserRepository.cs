using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using SaleCore.Domain.Entities;
using SaleCore.Infrastructure.Persistences.Contexts;
using SaleCore.Infrastructure.Persistences.Interfaces;

namespace SaleCore.Infrastructure.Persistences.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly SaleCoreContext _context;

        public UserRepository(SaleCoreContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> UserByEmail(string email)
        {
            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Email!.Equals(email));

            return user!;
        }

        public async Task<User> UserByUsername(string username)
        {
            var user = await _context.Users
            .AsNoTracking()
                .FirstOrDefaultAsync(x => x.UserName!.Equals(username));

            return user!;
        }
    }
}