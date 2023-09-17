using Application.Features.Auths.Dtos;
using Application.Services.AuthService;
using CoreFramework.Application.Responses;
using MediatR;
using MimeKit.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.LoginUser;
public class LoginUserCommand : IRequest<IDataResponse<LoginUserDto>>
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
}
public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IDataResponse<LoginUserDto>>
{
    readonly IAuthService _authService;
    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<IDataResponse<LoginUserDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var token = await _authService.LoginAsync(request.UsernameOrEmail, request.Password, 900);
        if (token is null)
            new ErrorDataResponse<LoginUserDto>();
        var result = new LoginUserDto(token);
        return new SuccessDataResponse<LoginUserDto>(result,"success");
    }

}