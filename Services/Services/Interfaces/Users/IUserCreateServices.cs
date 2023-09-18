using Services.Dtos;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IUserCreateServices : IServices<bool, UserDto>
{
}
