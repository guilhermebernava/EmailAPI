namespace Services.Dtos;

public class EmailDto
{
    public EmailDto(string? templateName, string? subject, string? html, List<string>? emailReceivers, bool emailReceiverFromDb = false, bool fromTemplate = false)
    {
        EmailReceivers = emailReceivers;
        EmailReceiverFromDb = emailReceiverFromDb;
        FromTemplate = fromTemplate;
        TemplateName = templateName;
        Subject = subject;
        Html = html;
    }

    public List<string>? EmailReceivers { get; set; }
    public bool EmailReceiverFromDb { get; set; }
    public bool FromTemplate { get; set; }
    public string? TemplateName { get; set; }
    public string? Subject { get; set; }
    public string? Html { get; set; }
}
