using MediatR;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;

public sealed record LoginCommand(
    string UsernameOrEmail,
    string Password) : IRequest<LoginCommandResponse>;
