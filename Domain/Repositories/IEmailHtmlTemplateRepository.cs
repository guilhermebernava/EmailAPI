using Domain.Entities;

namespace Domain.Repositories;

public interface IEmailHtmlTemplateRepository : IRepository<EmailHtmlTemplate>
{
    Task<EmailHtmlTemplate> GetByNameAsync(string name, CancellationToken cancellationToken = default);
}
