namespace CoreFramework.Security.Dtos;

public class UserForLoginDo
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string? AuthenticatorCode { get; set; }
}