using CleanArchitecture.Application.Abstraction.AbstractHandlers;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler : AuthHandler, IRequestHandler<ConfirmEmailCommand, MessageResponse>
    {
        public ConfirmEmailCommandHandler(IAuthService authService) : base(authService)
        {
        }

        public async Task<MessageResponse> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            await _authService.ConfirmEmail(request.userId, request.confirmationToken);

            return new MessageResponse("Email address has been confirmed successfully");
        }
    }
}
