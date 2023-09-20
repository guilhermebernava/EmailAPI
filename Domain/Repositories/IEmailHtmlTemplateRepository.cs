using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories;

public interface IEmailHtmlTemplateRepository : IRepository<EmailHtmlTemplate>
{
    Task<EmailHtmlTemplate> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<EmailHtmlTemplate>> GetByEmailTypeAsync(EEmailType type, CancellationToken cancellationToken = default);
}
