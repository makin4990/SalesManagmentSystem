using Application.Features.Auths.Dtos;
using Application.Services.AuthService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.AssignRoles;

public class AssignRoleCommandRequest : IRequest<AssignRoleDto>
{
    public string UserId { get; set; }
    public string[] Roles { get; set; }
}

public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommandRequest, AssignRoleDto>
{
    readonly IUserService _userService;
    public AssignRoleCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<AssignRoleDto> Handle(AssignRoleCommandRequest request, CancellationToken cancellationToken)
    {
        await _userService.AssignRoleToUserAsnyc(request.UserId, request.Roles);
        return new();
    }
}