namespace Application.Features.Auths.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string NameSurname { get; set; }
    public string UserName { get; set; }
    public bool TwoFactorEnabled { get; set; }
}
