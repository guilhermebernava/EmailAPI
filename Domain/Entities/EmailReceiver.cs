using Domain.Enums;

namespace Domain.Entities;

public class EmailReceiver : Entity
{
    public EmailReceiver()
    {
        
    }

    public EmailReceiver(string name, string email, EClientType clientType, bool recurring) : base() 
    {
        Name = name;
        Email = email;
        ClientType = clientType;
        Recurring = recurring;
    }

    public string Name { get; set; }
    public  EClientType ClientType { get; set; }
    public string Email { get; set; }
    public bool Recurring { get; set; }
}
