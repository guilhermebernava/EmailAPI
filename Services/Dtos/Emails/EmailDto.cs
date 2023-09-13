namespace Services.Dtos;

public class EmailDto
{
    public EmailDto(string emailTo, string subject, string html)
    {
        EmailTo = emailTo;
        Subject = subject;
        Html = html;
    }

    public string EmailTo { get; set; }
    public string Subject { get; set; }
    public string Html { get; set; }
}
