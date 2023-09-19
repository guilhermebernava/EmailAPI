using Domain.Entities;
using Services.Services.Interfaces;

namespace Services.Services;

public interface IEmailHtmlTemplateGetAllServices : IServices<IEnumerable<EmailHtmlTemplate>>
{
}
