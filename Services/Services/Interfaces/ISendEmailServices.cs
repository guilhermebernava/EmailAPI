using Services.Dtos;

namespace Services.Services;

public   interface ISendEmailServices
{
    Task<bool> ExecuteAsync(EmailDto dto);
}
