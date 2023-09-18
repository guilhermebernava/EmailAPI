using Services.Dtos;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IUserLoginServices : IServices<string,LoginDto>
{
}
