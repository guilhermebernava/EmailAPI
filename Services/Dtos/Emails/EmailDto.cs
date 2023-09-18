namespace Services.Dtos;

public class EmailDto
{
    public EmailDto(List<string> emailReceivers, string html, string subject)
    {
        EmailReceivers = emailReceivers;
        Html = html;
        Subject = subject;
    }

    public List<string> EmailReceivers { get; set; }
    public string Subject { get; set; }
    public string Html { get; set; }
}
