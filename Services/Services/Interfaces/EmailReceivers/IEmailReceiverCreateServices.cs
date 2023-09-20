using Services.Dtos;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IEmailReceiverCreateServices : IServices<bool, EmailReceiverDto>
{
}
