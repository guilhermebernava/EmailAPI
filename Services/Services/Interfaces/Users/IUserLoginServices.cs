using Services.Dtos.Users;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IUserLoginServices : IServices<string,LoginDto>
{
}
