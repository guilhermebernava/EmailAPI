using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Infra.Data;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories;

public class EmailReceiverRepository : Repository<EmailReceiver>, IEmailReceiverRepository
{
    public EmailReceiverRepository(AppDbContext db, ILogger<Repository<EmailReceiver>> logger) : base(db, logger)
    {
    }

    public async Task<IEnumerable<EmailReceiver>> GetByClientType(EClientType clientType, CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _dbSet.Where(_ => _.ClientType == clientType).ToListAsync(cancellationToken);
            return entities;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<EmailReceiver> GetByEmail(string email, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Email == email, cancellationToken);
            return entity ?? throw new RepositoryException($"Not found any user with this Email - {email}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<EmailReceiver> GetByName(string name, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Name == name, cancellationToken);
            return entity ?? throw new RepositoryException($"Not found any user with this Name - {name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<IEnumerable<EmailReceiver>> GetByRecurring(bool recurring = true, CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _dbSet.Where(_ => _.Recurring == recurring).ToListAsync(cancellationToken);
            return entities;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }
}
