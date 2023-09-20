using Domain.Utils;
using Xunit;

namespace Domain.Tests.Utils;
public class PasswordUtilsTests
{
    [Fact]
    public void GeneratePassword_ReturnsValidHashAndSalt()
    {
        string password = "MySecurePassword";
        var (hash, salt) = PasswordUtils.GeneratePassword(password);

        Assert.NotNull(hash);
        Assert.NotNull(salt);
        Assert.True(hash.Length > 0);
        Assert.True(salt.Length == 16);
    }

    [Fact]
    public void ValidatePassword_ValidPassword_ReturnsTrue()
    {
        string password = "MySecurePassword";
        var (hash, salt) = PasswordUtils.GeneratePassword(password);

        bool isValid = PasswordUtils.ValidatePassword(password, hash, salt);
        Assert.True(isValid);
    }

    [Fact]
    public void ValidatePassword_InvalidPassword_ReturnsFalse()
    {
        string correctPassword = "MySecurePassword";
        string incorrectPassword = "WrongPassword";
        var (hash, salt) = PasswordUtils.GeneratePassword(correctPassword);

        bool isValid = PasswordUtils.ValidatePassword(incorrectPassword, hash, salt);
        Assert.False(isValid);
    }
}
