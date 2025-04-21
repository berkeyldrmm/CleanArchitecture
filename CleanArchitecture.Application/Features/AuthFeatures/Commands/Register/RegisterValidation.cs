using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.AuthFeatures.Commands.Register
{
    public class RegisterValidation : AbstractValidator<RegisterCommand>
    {
        public RegisterValidation()
        {
            RuleFor(c => c.Email).NotEmpty().WithMessage("Email field is required!");
            RuleFor(c => c.Email).NotNull().WithMessage("Email field is required!");
            RuleFor(c => c.Email).EmailAddress().WithMessage("Please enter a valid email address!");

            RuleFor(c => c.Username).NotEmpty().WithMessage("Username field is required!");
            RuleFor(c => c.Username).NotNull().WithMessage("Username field is required!");
            RuleFor(c => c.Username).MinimumLength(3).WithMessage("Username must be greater than 3 characters!");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Password field is required!");
            RuleFor(p => p.Password).NotNull().WithMessage("Password field is required!");
            RuleFor(p => p.Password).Matches("[A-Z]").WithMessage("Password must contain at least 1 capital character!");
            RuleFor(p => p.Password).Matches("[a-z]").WithMessage("Password must contain at least 1 lower character!");
            RuleFor(p => p.Password).Matches("[0-9]").WithMessage("Password must contain at least 1 numeric character!");
            RuleFor(p => p.Password).Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least 1 special character!");

            RuleFor(p => p.Password).Equal(p => p.PasswordConfirm).WithMessage("Passwords does not match!");
        }
    }
}
