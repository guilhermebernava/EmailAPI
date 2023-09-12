using Domain.Utils;

namespace Domain.Entities;

public class User : Entity
{
    public User()
    {

    }

    public User(string email, string password) : base()
    {
        Email = email;
        var (hashpassword, salt) = PasswordUtils.GeneratePassword(password);
        HashedPassword = hashpassword;
        Salt = salt;
    }

    public string Email { get; set; }
    public string HashedPassword { get; set; }
    public byte[] Salt { get; set; }
}
