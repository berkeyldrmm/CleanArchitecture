using CleanArchitecture.Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public sealed record RegisterCommand(
        string NameSurname,
        string Email,
        string Username,
        string Password,
        string PasswordConfirm) : IRequest<MessageResponse>;
}
