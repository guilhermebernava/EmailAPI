using Domain.Enums;

namespace Services.Dtos;

public class EmailReceiverUpdateDto
{
    public EmailReceiverUpdateDto(Guid id,string name, EClientType clientType, string email, bool recurring)
    {
        Name = name;
        Id = id;
        ClientType = clientType;
        Email = email;
        Recurring = recurring;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public EClientType ClientType { get; set; }
    public string Email { get; set; }
    public bool Recurring { get; set; }
}