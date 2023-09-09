using AutoMapper;
using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands.CreateUser;

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
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;
    //private readonly UserBusinessRules _userBusinessRules;

    public CreateUserCommandHandler(IMapper mapper, UserManager<User> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    public async Task<CreateUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        User mappedUser = _mapper.Map<User>(request);
        IdentityResult createdUser = await _userManager.CreateAsync(mappedUser);
        if (!createdUser.Succeeded)
            return null;
        CreateUserDto createdUserDto = _mapper.Map<CreateUserDto>(mappedUser);
        return createdUserDto;
    }
}
