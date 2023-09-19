using Services.Dtos;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IEmailHtmlTemplateCreateServices : IServices<bool, EmailHtmlTemplateDto>
{
}
