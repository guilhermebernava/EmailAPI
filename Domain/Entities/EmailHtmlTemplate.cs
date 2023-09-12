using Domain.Enums;

namespace Domain.Entities;

public class EmailHtmlTemplate : Entity
{
    public EmailHtmlTemplate()
    {
        
    }

    public EmailHtmlTemplate(string name, string htmlContent, string? cssContent, EEmailType emailType) : base()
    {
        Name = name;
        HtmlContent = htmlContent;
        CssContent = cssContent;
        EmailType = emailType;
    }

    public string Name { get; set; }
    public EEmailType EmailType { get; set; }
    public string HtmlContent { get; set; }
    public string? CssContent { get; set; }
}
