using Domain.Entities;
using Domain.Repositories;

namespace Services.Services;

public class EmailReceiverGetAllServices : IEmailReceiverGetAllServices
{
    private readonly IEmailReceiverRepository _repository;

    public EmailReceiverGetAllServices(IEmailReceiverRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<EmailReceiver>> ExecuteAsync()
    {
        return await _repository.GetAllAsync();
    }
}
