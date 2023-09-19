using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories;

public interface IEmailReceiverRepository : IRepository<EmailReceiver>
{
    Task<IEnumerable<EmailReceiver>> GetByClientTypeAsync(EClientType clientType, CancellationToken cancellationToken = default);
    Task<EmailReceiver> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    Task<EmailReceiver> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<EmailReceiver>> GetByRecurringAsync(bool recurring = true, CancellationToken cancellationToken = default);
}
