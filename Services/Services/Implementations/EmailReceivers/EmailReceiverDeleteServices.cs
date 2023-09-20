using Domain.Repositories;

namespace Services.Services;

public class EmailReceiverDeleteServices : IEmailReceiverDeleteServices
{
    private readonly IEmailReceiverRepository _repository;

    public EmailReceiverDeleteServices(IEmailReceiverRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(Guid paramter)
    {
        return await _repository.DeleteAsync(paramter);
    }
}
