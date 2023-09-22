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

    public async Task<IEnumerable<EmailReceiver>> GetByClientTypeAsync(EClientType clientType, CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _dbSet.Where(_ => _.ClientType == clientType && _.DeletedAt == null).ToListAsync(cancellationToken);
            return entities;
        }
        catch (Exception ex)
        {
            _logger.LogError("[EmailReceiverRepository] - " + ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<EmailReceiver> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Email == email && _.DeletedAt == null, cancellationToken);
            return entity ?? throw new RepositoryException($"Not found any user with this Email - {email}");
        }
        catch (Exception ex)
        {
            _logger.LogError("[EmailReceiverRepository] - " + ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<EmailReceiver> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Name == name && _.DeletedAt == null, cancellationToken);
            return entity ?? throw new RepositoryException($"Not found any user with this Name - {name}");
        }
        catch (Exception ex)
        {
            _logger.LogError("[EmailReceiverRepository] - " + ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<IEnumerable<EmailReceiver>> GetByRecurringAsync(bool recurring = true, CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _dbSet.Where(_ => _.Recurring == recurring && _.DeletedAt == null).ToListAsync(cancellationToken);
            return entities;
        }
        catch (Exception ex)
        {
            _logger.LogError("[EmailReceiverRepository] - " + ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }
}
