using Domain.Entities;
using Domain.Repositories;
using Infra.Data;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories;

public class Repository<T> : IRepository<T> where T : Entity
{
    private readonly AppDbContext _db;
    public readonly DbSet<T> _dbSet;
    public readonly ILogger<Repository<T>> _logger;

    public Repository(AppDbContext db, ILogger<Repository<T>> logger)
    {
        _db = db;
        _dbSet = db.Set<T>();
        _logger = logger;
    }

    public async Task<bool> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        try
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return await SaveAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await GetByIdAsync(id, cancellationToken);
            _dbSet.Remove(entity);
            return await SaveAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _dbSet.ToListAsync(cancellationToken);
            return entities;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Id == id, cancellationToken);
            return entity ?? throw new RepositoryException($"Not found any user with this ID - {id}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _db.SaveChangesAsync(cancellationToken) == 1;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        try
        {
            _dbSet.Update(entity);
            return await SaveAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }
}
