using AutoMapper;
using Application.Features.Auths.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Application.Services.AuthService;

namespace Application.Features.Auths.Commands.CreateUser;

public class CreateUserCommand:IRequest<CreateUserDto>
{
    public string UserName{get; set;}
    public string Name {get; set;}
    public string SurName {get; set;}
    public string FullName {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public string PasswordConfirm {get; set;}


}
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserDto>
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IMapper mapper, IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var createdUser = await _userService.CreateAsync(request);
        if (createdUser is  null)
            return new();
        return createdUser;
    }
}
