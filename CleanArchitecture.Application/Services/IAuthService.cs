using CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Login;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Services
{
    public interface IAuthService
    {
        Task Register(RegisterCommand command);
        Task SendConfirmEmail(string id);
        Task ConfirmEmail(string userId, string token);
        Task<LoginCommandResponse> LoginAsync(LoginCommand request, CancellationToken cancellationToken);
        Task<LoginCommandResponse> CreateNewTokenByRefreshToken(CreateNewTokenByRefreshTokenCommand request, CancellationToken cancellationToken);
    }
}
