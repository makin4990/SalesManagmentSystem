using Application.Features.Auths.Dtos;
using Application.Services.AuthService;
using MediatR;


namespace Application.Features.Auths.Commands.VerifyResetToken;

public class VerifyResetTokenCommand : IRequest<VerifyResetTokenDto>
{
    public string ResetToken { get; set; }
    public string UserId { get; set; }
}
public class VerifyResetTokenCommandHandler : IRequestHandler<VerifyResetTokenCommand, VerifyResetTokenDto>
{
    readonly IAuthService _authService;

    public VerifyResetTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<VerifyResetTokenDto> Handle(VerifyResetTokenCommand request, CancellationToken cancellationToken)
    {
        bool state = await _authService.VerifyResetTokenAsync(request.ResetToken, request.UserId);
        return new()
        {
            State = state
        };
    }
}
