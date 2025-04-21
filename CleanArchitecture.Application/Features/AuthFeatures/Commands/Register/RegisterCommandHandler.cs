using CleanArchitecture.Application.Abstraction.AbstractHandlers;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed class RegisterCommandHandler : AuthHandler, IRequestHandler<RegisterCommand, MessageResponse>
    {
        public RegisterCommandHandler(IAuthService authService) : base(authService)
        {
        }

        public async Task<MessageResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authService.Register(request);
            return new MessageResponse("User has been saved successfully!");
        }
    }
}
