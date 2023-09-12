namespace Services.Dtos.Users;

public class UserDto
{
    public UserDto(string email, string password, Guid? id)
    {
        Email = email;
        Password = password;
        Id = id;
    }

    public Guid? Id { get;set; } 
    public string Email { get; set; }
    public string Password { get; set; }
}
