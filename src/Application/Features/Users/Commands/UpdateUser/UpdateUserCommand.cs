using AutoMapper;
using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Application.Features.Users.Commands.UpdateUser;

public class UpdateUserCommand: IRequest<UpdateUserDto>
{
    public int Id {get; set;}
    public string UserName { get; set; }
    public string Name {get; set;}
    public string SurName {get; set;}
    public string FullName {get; set;}
    public DateTime CreatedAt {get; set;}
    public DateTime UpdatedAt {get; set;}
    public string Email {get; set;}
    public string Password {get; set;}
    public string PasswordConfirm {get; set;}
}

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand,UpdateUserDto>
{
    private readonly UserManager<User> _userManager;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(UserManager<User> userRepository, IMapper mapper)
    {
        _userManager = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {

        User? entityToUpdate = await _userManager.FindByEmailAsync(request.Email);
        User? mappedUser = _mapper.Map(request,entityToUpdate);
        IdentityResult Updated = await _userManager.UpdateAsync(mappedUser);

        if (!Updated.Succeeded)
            return null;

        var result = _mapper.Map<UpdateUserDto>(mappedUser);

        return result;
    }
}

