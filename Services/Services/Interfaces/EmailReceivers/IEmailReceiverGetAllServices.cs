using Domain.Entities;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IEmailReceiverGetAllServices : IServices<IEnumerable<EmailReceiver>>
{
}
