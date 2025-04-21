using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.ConfirmEmail
{
    public sealed record ConfirmEmailCommand(
        string userId,
        string confirmationToken) : IRequest<MessageResponse>;
}
