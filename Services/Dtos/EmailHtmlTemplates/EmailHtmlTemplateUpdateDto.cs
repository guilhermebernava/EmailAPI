using Domain.Enums;

namespace Services.Dtos;
public record EmailHtmlTemplateUpdateDto(Guid Id,string Name, EEmailType EmailType, string HtmlContent, string Subject);
