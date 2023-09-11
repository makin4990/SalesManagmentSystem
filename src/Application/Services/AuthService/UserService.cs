using Microsoft.AspNetCore.Identity;
using User = Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Auths.Dtos;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Application.Helpers;
using Microsoft.EntityFrameworkCore;
using Application.Features.Auths.Commands.CreateUser;
using MediatR;
using Application.Features.Auths.Commands.UpdateUser;

namespace Application.Services.AuthService;

public class UserService : IUserService
{
    readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UserService(UserManager<User> userManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

    public async Task<CreateUserDto> CreateAsync(CreateUserCommand model)
    {
        User User = _mapper.Map<User>(model);


        IdentityResult result = await _userManager.CreateAsync(User,model.Password);
        if (!result.Succeeded)
            return new CreateUserDto();
        //hata kodları result'ın altında var
        var mappingResult = _mapper.Map<CreateUserDto>(User);
        return mappingResult;
    }
    public async Task UpdateRefreshTokenAsync(string refreshToken, User user, DateTime accessTokenDate, int addOnAccessTokenDate)
    {
        if (user != null)
        {
            user.RefreshToken = refreshToken;
            user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
            await _userManager.UpdateAsync(user);
        }
        else
            throw new Exception();
    }
    public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
    {
        User user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            resetToken = resetToken.UrlDecode();
            IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (result.Succeeded)
                await _userManager.UpdateSecurityStampAsync(user);
            else
                throw new Exception();
        }
    }

    public async Task<List<UserDto>> GetAllUsersAsync(int page, int size)
    {
        var users = await _userManager.Users
              .Skip(page * size)
              .Take(size)
              .ToListAsync();

        return users.Select(user => new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            NameSurname = user.FullName,
            TwoFactorEnabled = user.TwoFactorEnabled,
            UserName = user.UserName

        }).ToList();
    }

    public int TotalUsersCount => _userManager.Users.Count();

    public async Task AssignRoleToUserAsnyc(string userId, string[] roles)
    {
        User user = await _userManager.FindByIdAsync(userId);
        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, userRoles);

            await _userManager.AddToRolesAsync(user, roles);
        }
    }
    public async Task<string[]> GetUserRolesAsync(string userIdOrName)
    {
        User user = await _userManager.FindByIdAsync(userIdOrName);
        if (user == null)
            user = await _userManager.FindByNameAsync(userIdOrName);

        if (user != null)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.ToArray();
        }
        return new string[] { };
    }

    public async Task<bool> HasRolePermissionToEndpointAsync(string name, string code)
    {
        return false;
    }
    public async Task<UpdateUserDto> UpdateUserProfileInfo(UpdateUserCommand model)
    {
        User? entityToUpdate = await _userManager.FindByEmailAsync(model.Email);
        User? mappedUser = _mapper.Map(model, entityToUpdate);
        IdentityResult Updated = await _userManager.UpdateAsync(mappedUser);

        if (!Updated.Succeeded)
            return null;

        var result = _mapper.Map<UpdateUserDto>(mappedUser);

        return result;
    }
}