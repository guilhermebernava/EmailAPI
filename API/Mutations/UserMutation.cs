using HotChocolate.Authorization;
using Services.Dtos.Users;
using Services.Services;

namespace API.Mutations;

public class UserMutation
{
    public async Task<bool> CreateUserAsync([Service] IUserCreateServices services, UserDto dto)
    {
        dto.Id = null;
        return await services.ExecuteAsync(dto);
    }

    [Authorize]
    public async Task<bool> UpdateUserAsync([Service] IUserUpdateServices services, UserDto dto)
    {
        return await services.ExecuteAsync(dto);
    }

    [Authorize]
    public async Task<bool> DeleteUserAsync([Service] IUserDeleteServices services, Guid id)
    {
        return await services.ExecuteAsync(id);
    }

    public async Task<string> LoginAsync([Service] IUserLoginServices services, LoginDto dto)
    {
        return await services.ExecuteAsync(dto);
    }
}
