namespace WebUI.Models.Accounts.Register;


public class RegisterUserDto
{
    public string UserName { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }
    public string FullName { get { return $"{Name} {SurName}"; } }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirm { get; set; }
}
