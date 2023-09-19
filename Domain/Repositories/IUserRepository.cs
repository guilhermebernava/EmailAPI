using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<User> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
}
