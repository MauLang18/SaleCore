using SaleCore.Domain.Entities;

namespace SaleCore.Infrastructure.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> UserByEmail(string email);
        Task<User> UserByUsername(string username);
    }
}