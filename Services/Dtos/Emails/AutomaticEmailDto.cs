namespace Services.Dtos;

public class AutomaticEmailDto
{
    public AutomaticEmailDto(EmailDto emailDto, string name, string cron)
    {
        EmailDto = emailDto;
        Name = name;
        Cron = cron;
    }

    public EmailDto EmailDto { get; set; }
    public string Name { get; set; }
    public string Cron { get; set; }
}
