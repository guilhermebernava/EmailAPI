using Domain.Entities;
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
            var entity = await _dbSet.FirstOrDefaultAsync(_ => _.Name == name, cancellationToken);
            return entity ?? throw new RepositoryException($"Not found any user with this NAME - {name}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw new RepositoryException(ex.Message);
        }
    }
}
