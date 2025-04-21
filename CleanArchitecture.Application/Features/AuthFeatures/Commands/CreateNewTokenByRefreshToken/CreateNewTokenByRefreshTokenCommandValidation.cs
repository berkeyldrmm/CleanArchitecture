using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.CreateNewTokenByRefreshToken
{
    public class CreateNewTokenByRefreshTokenCommandValidation : AbstractValidator<CreateNewTokenByRefreshTokenCommand>
    {
        public CreateNewTokenByRefreshTokenCommandValidation()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User can not be empty!");
            RuleFor(c => c.UserId).NotNull().WithMessage("User can not be empty!");

            RuleFor(c => c.RefreshToken).NotEmpty().WithMessage("Refresh token can not be empty!");
            RuleFor(c => c.RefreshToken).NotNull().WithMessage("Refresh token can not be empty!");
        }
    }
}
