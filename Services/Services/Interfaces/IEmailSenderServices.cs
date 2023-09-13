using Services.Dtos;

namespace Services.Services;

public interface IEmailSenderServices
{
    Task<bool> ExecuteAsync(EmailDto dto);
}
