namespace Application.Features.Auths.Dtos;

public class UserListModelDto
{
    public int Id {get; set;}
    public string Name {get; set;}
    public string SurName {get; set;}
    public string FullName {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public string PasswordConfirm {get; set;}
}
