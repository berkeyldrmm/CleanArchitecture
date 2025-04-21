using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.UserRoleFeatures.Commands.CreateUserRole
{
    public class CreateUserRoleValidator : AbstractValidator<CreateUserRoleCommand>
    {
        public CreateUserRoleValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User ID is required!");
            RuleFor(c => c.UserId).NotNull().WithMessage("User ID is required!");
            RuleFor(c => c.RoleId).NotEmpty().WithMessage("Role ID is required!");
            RuleFor(c => c.RoleId).NotNull().WithMessage("Role ID is required!");
        }
    }
}
