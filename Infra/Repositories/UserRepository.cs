using Domain.Entities;
using Domain.Repositories;
using Domain.Utils;
using Infra.Data;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext db, ILogger<Repository<User>> logger) : base(db, logger)
    {
    }

    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Email == email,cancellationToken);
            return entity ?? throw new RepositoryException($"Not found any user with this EMAIL - {email}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<User> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await GetByEmail(email, cancellationToken);
            if (!PasswordUtils.ValidatePassword(password, entity.HashedPassword, entity.Salt)) throw new UnauthorizedAccessException("Invalid EMAIL or PASSWORD");
            return entity;
        }
        catch(UnauthorizedAccessException ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }
}
