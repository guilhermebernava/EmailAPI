using Domain.Enums;

namespace Services.Dtos;

public record EmailHtmlTemplateDto(string Name, EEmailType EmailType, string HtmlContent, string Subject);
