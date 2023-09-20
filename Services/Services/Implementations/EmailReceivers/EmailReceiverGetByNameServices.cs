using Domain.Entities;
using Domain.Repositories;

namespace Services.Services;

public class EmailReceiverGetByNameServices : IEmailReceiverGetByNameServices
{
    private readonly IEmailReceiverRepository _repository;

    public EmailReceiverGetByNameServices(IEmailReceiverRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmailReceiver> ExecuteAsync(string name)
    {
        return await _repository.GetByNameAsync(name);
    }
}
