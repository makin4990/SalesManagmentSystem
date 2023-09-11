using AutoMapper;
using Application.Features.Auths.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Application.Services.AuthService;

namespace Application.Features.Auths.Commands.UpdateUser;

public class UpdateUserCommand: IRequest<UpdateUserDto>
{
    public int Id {get; set;}
    public string UserName { get; set; }
    public string Name {get; set;}
    public string SurName {get; set;}
    public string FullName {get; set;}
    public string Email { get; set; }
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand,UpdateUserDto>
{
    private readonly IUserService _userService;

    public UpdateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        return await _userService.UpdateUserProfileInfo(request);
    }
}

