using Application.Features.Auths.Commands.PasswordReset;
using Application.Features.Auths.Dtos;
using Application.Services.AuthService;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.RefreshTokenLogin;

public class RefreshTokenLoginCommand : IRequest<RefreshTokenLoginDto>
{
    public string RefreshToken { get; set; }
}
public class RefreshTokenLoginCommandHandler : IRequestHandler<RefreshTokenLoginCommand, RefreshTokenLoginDto>
{
    readonly IAuthService _authService;
    public RefreshTokenLoginCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<RefreshTokenLoginDto> Handle(RefreshTokenLoginCommand request, CancellationToken cancellationToken)
    {
        Token token = await _authService.RefreshTokenLoginAsync(request.RefreshToken);
        return new()
        {
            Token = token
        };
    }
}

