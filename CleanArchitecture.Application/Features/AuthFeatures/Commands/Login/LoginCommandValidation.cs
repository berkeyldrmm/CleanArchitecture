using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Login
{
    public class LoginCommandValidation : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidation()
        {
            RuleFor(c => c.UsernameOrEmail).NotEmpty().WithMessage("Username or email field is required!");
            RuleFor(c => c.UsernameOrEmail).NotNull().WithMessage("Username or email field is required!");
            RuleFor(c => c.UsernameOrEmail).MinimumLength(3).WithMessage("Username or email must be greater than 3 characters!");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Password field is required!");
            RuleFor(p => p.Password).NotNull().WithMessage("Password field is required!");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Password must contain at least 1 capital character!");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Password must contain at least 1 lower character!");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Password must contain at least 1 numeric character!");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least 1 special character!");

        }
    }
}
