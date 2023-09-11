using Application.Features.Auths.Dtos;
using Application.Services.AuthService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Features.Auths.Commands.PasswordReset;
public class PasswordResetCommand : IRequest<PasswordResetDto>
{
    public string Email { get; set; }
}

public class PasswordResetCommandHandler : IRequestHandler<PasswordResetCommand, PasswordResetDto>
{
    readonly IAuthService _authService;

    public PasswordResetCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<PasswordResetDto> Handle(PasswordResetCommand request, CancellationToken cancellationToken)
    {
        await _authService.PasswordResetAsnyc(request.Email);
        return new();
    }
   
}