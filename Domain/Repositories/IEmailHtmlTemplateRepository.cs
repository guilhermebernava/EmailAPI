using Domain.Entities;

namespace Domain.Repositories;

public interface IEmailHtmlTemplateRepository : IRepository<EmailHtmlTemplate>
{
    Task<EmailHtmlTemplate> GetByEmail(string email, CancellationToken cancellationToken = default);
    Task<bool> LoginAsync(string email, string password, CancellationToken cancellationToken = default);
}
