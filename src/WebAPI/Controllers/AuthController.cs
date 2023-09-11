using Application.Features.Auths.Commands.LoginUser;
using Application.Features.Auths.Commands.PasswordReset;
using Application.Features.Auths.Commands.RefreshTokenLogin;
using Application.Features.Auths.Commands.VerifyResetToken;
using Application.Features.Auths.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : BaseController
{
    private readonly IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("[action]")]
    public async Task<IActionResult> Login(LoginUserCommand loginUserCommandRequest)
    {
        var response = await _mediator.Send(loginUserCommandRequest);
        return Ok(response);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshTokenLogin([FromBody] RefreshTokenLoginCommand refreshTokenLoginCommandRequest)
    {
        var response = await _mediator.Send(refreshTokenLoginCommandRequest);
        return Ok(response);
    }

    [HttpPost("password-reset")]
    public async Task<IActionResult> PasswordReset([FromBody] PasswordResetCommand passwordResetCommandRequest)
    {
        PasswordResetDto response = await _mediator.Send(passwordResetCommandRequest);
        return Ok(response);
    }

    [HttpPost("verify-reset-token")]
    public async Task<IActionResult> VerifyResetToken([FromBody] VerifyResetTokenCommand verifyResetTokenCommand)
    {
        VerifyResetTokenDto response = await _mediator.Send(verifyResetTokenCommand);
        return Ok(response);
    }

}
