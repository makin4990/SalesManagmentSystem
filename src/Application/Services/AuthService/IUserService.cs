using Application.Features.Auths.Commands.CreateUser;
using Application.Features.Auths.Commands.UpdateUser;
using Application.Features.Auths.Dtos;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService;

public interface IUserService
{
    Task<CreateUserDto> CreateAsync(CreateUserCommand model);
    Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate);
    Task UpdatePasswordAsync(string userId, string resetToken, string newPassword);
    Task<List<UserDto>> GetAllUsersAsync(int page, int size);
    int TotalUsersCount { get; }
    Task AssignRoleToUserAsnyc(string userId, string[] roles);
    Task<string[]> GetUserRolesAsync(string userIdOrName);
    Task<bool> HasRolePermissionToEndpointAsync(string name, string code);
    Task<UpdateUserDto> UpdateUserProfileInfo(UpdateUserCommand model);
}
