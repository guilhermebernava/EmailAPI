namespace Services.Dtos;

public class AutomaticEmailDto
{
    public AutomaticEmailDto(EmailDto emailDto, string name)
    {
        EmailDto = emailDto;
        Name = name;
    }

    public EmailDto EmailDto { get; set; }
    public string Name { get; set; }
}
