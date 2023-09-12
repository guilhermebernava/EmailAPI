using Domain.Repositories;

namespace Services.Services;

public class UserDeleteServices : IUserDeleteServices
{
    private readonly IUserRepository _repository;

    public UserDeleteServices(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> ExecuteAsync(Guid paramter)
    {
        return await _repository.DeleteAsync(paramter);
    }
}
