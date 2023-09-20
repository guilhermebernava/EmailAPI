using Domain.Entities;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IEmailReceiverGetByNameServices : IServices<EmailReceiver, string>
{
}
