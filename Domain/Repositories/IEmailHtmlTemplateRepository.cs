using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories;

public interface IEmailHtmlTemplateRepository : IRepository<EmailHtmlTemplate>
{
    Task<EmailHtmlTemplate> GetByName(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<EmailHtmlTemplate>> GetByType(EEmailType type, CancellationToken cancellationToken = default);
}
