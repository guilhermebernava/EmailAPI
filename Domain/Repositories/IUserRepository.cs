using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmail(string email, CancellationToken cancellationToken = default);
    Task<User> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
}
