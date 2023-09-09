using CoreFramework.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;
public class User:IdentityUser<int>
{
    public string FullName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenEndDate { get; set; }
}
