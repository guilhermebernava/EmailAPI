using Services.Dtos;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IEmailReceiverUpdateServices : IServices<bool,EmailReceiverUpdateDto>
{
}
