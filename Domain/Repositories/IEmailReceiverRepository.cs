using Domain.Entities;
using Domain.Enums;

namespace Domain.Repositories;

public interface IEmailReceiverRepository : IRepository<EmailReceiver>
{
    Task<IEnumerable<EmailReceiver>> GetByClientType(EClientType clientType, CancellationToken cancellationToken = default);
    Task<EmailReceiver> GetByEmail(string email, CancellationToken cancellationToken = default);
    Task<EmailReceiver> GetByName(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<EmailReceiver>> GetByRecurring(bool recurring = true, CancellationToken cancellationToken = default);
}
