using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar
{
    public class CreateCarValidation : AbstractValidator<CreateCarCommand>
    {
        public CreateCarValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Car name cannot be empty!");
            RuleFor(c => c.Name).NotNull().WithMessage("Car name cannot be empty!");
            RuleFor(c => c.Name).MinimumLength(3).WithMessage("Car name cannot be less than 3 characters!");

            RuleFor(c => c.Model).NotEmpty().WithMessage("Car model cannot be empty!");
            RuleFor(c => c.Model).NotNull().WithMessage("Car model cannot be empty!");
            RuleFor(c => c.Model).MinimumLength(3).WithMessage("Car model cannot be less than 3 characters!");

            RuleFor(c => c.EnginePower).NotEmpty().WithMessage("Car engine power cannot be empty!");
            RuleFor(c => c.EnginePower).NotNull().WithMessage("Car engine power cannot be empty!");
            RuleFor(c => c.EnginePower).GreaterThan(0).WithMessage("Car engine power must be greater than 0!");
        }
    }

    //public class OtherCreateCarValidation : AbstractValidator<CreateCarCommand>
    //{
    //    public OtherCreateCarValidation()
    //    {
    //        RuleFor(c => c.EnginePower).LessThan(10000).WithMessage("Car engine power must be less than 10000!");
    //    }
    //}
}
