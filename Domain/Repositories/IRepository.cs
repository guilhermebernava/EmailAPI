using Domain.Entities;

namespace Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<bool> CreateAsync(T entity,CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> SaveAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T> GetById(Guid id, CancellationToken cancellationToken = default);
}
