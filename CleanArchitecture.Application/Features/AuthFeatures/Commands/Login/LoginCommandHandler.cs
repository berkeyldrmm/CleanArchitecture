using CleanArchitecture.Application.Abstraction.AbstractHandlers;
using CleanArchitecture.Application.Services;
using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public sealed class LoginCommandHandler : AuthHandler, IRequestHandler<LoginCommand, LoginCommandResponse>
{
    public LoginCommandHandler(IAuthService authService) : base(authService)
    {
    }

    public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
       return await _authService.LoginAsync(request, cancellationToken);
    }
}
