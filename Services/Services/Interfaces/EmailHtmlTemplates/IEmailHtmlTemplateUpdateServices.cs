using Services.Dtos;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IEmailHtmlTemplateUpdateServices : IServices<bool,EmailHtmlTemplateUpdateDto>
{
}
