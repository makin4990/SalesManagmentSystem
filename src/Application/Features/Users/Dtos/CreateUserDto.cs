namespace Application.Features.Users.Dtos;

public class CreateUserDto
{
    public string UserName { get; set; }
    public string Name {get; set;}
    public string SurName {get; set;}
    public string FullName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public string PasswordConfirm {get; set;}
}
