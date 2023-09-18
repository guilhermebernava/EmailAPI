using Domain.Entities;

namespace Domain.Repositories;

public interface IEmailHtmlTemplateRepository : IRepository<EmailHtmlTemplate>
{
    Task<EmailHtmlTemplate> GetByName(string name, CancellationToken cancellationToken = default);
}
