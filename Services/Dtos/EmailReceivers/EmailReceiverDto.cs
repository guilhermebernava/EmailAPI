using Domain.Enums;

namespace Services.Dtos;

public class EmailReceiverDto
{
    public EmailReceiverDto(string name, EClientType clientType, string email, bool recurring)
    {
        Name = name;
        ClientType = clientType;
        Email = email;
        Recurring = recurring;
    }

    public string Name { get; set; }
    public EClientType ClientType { get; set; }
    public string Email { get; set; }
    public bool Recurring { get; set; }
}
