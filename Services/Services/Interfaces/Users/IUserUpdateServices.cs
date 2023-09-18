using Services.Dtos;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IUserUpdateServices : IServices<bool,UserDto>
{
}
