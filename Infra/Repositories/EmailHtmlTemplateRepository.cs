using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using Infra.Data;
using Infra.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infra.Repositories;

public class EmailHtmlTemplateRepository : Repository<EmailHtmlTemplate>, IEmailHtmlTemplateRepository
{
    public EmailHtmlTemplateRepository(AppDbContext db, ILogger<Repository<EmailHtmlTemplate>> logger) : base(db, logger)
    {
    }

    public async Task<EmailHtmlTemplate> GetByName(string name, CancellationToken cancellationToken = default)
    {
        try
        {
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Name == name && _.DeletedAt != null, cancellationToken);
            return entity ?? throw new RepositoryException($"Not found any user with this EMAIL - {name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }

    public async Task<IEnumerable<EmailHtmlTemplate>> GetByType(EEmailType type, CancellationToken cancellationToken = default)
    {
        try
        {
            var entities = await _dbSet.Where(_ => _.EmailType == type && _.DeletedAt != null).ToListAsync(cancellationToken);
            return entities;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }
}
