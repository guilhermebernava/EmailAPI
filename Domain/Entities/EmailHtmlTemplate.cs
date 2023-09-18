using Domain.Enums;

namespace Domain.Entities;

public class EmailHtmlTemplate : Entity
{
    public EmailHtmlTemplate()
    {
        
    }

    public EmailHtmlTemplate(string name, string htmlContent, string subject, EEmailType emailType) : base()
    {
        Name = name;
        HtmlContent = htmlContent;
        Subject = subject;
        EmailType = emailType;
    }

    public string Name { get; set; }
    public EEmailType EmailType { get; set; }
    public string HtmlContent { get; set; }
    public string Subject { get; set; }
}
