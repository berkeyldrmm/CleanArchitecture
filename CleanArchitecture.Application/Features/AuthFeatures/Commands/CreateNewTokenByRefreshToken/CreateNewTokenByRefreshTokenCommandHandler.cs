using CleanArchitecture.Application.Abstraction.AbstractHandlers;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;

public class CreateNewTokenByRefreshTokenCommandHandler : AuthHandler, IRequestHandler<CreateNewTokenByRefreshTokenCommand, LoginCommandResponse>
{
    public CreateNewTokenByRefreshTokenCommandHandler(IAuthService authService) : base(authService)
    {
    }

    public async Task<LoginCommandResponse> Handle(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
    {
        return await _authService.CreateNewTokenByRefreshToken(request, cancellationToken);
    }
}
