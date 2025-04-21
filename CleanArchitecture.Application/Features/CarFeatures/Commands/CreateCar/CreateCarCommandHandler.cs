using CleanArchitecture.Application.Abstraction.AbstractHandlers;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;

public sealed class CreateCarCommandHandler : CarHandler, IRequestHandler<CreateCarCommand, MessageResponse>
{
    public CreateCarCommandHandler(ICarService carService) : base(carService)
    {
    }

    public async Task<MessageResponse> Handle(CreateCarCommand request, CancellationToken cancellationToken)
    {
        await _carService.CreateCar(request, cancellationToken);

        return new("Car has been saved successfully!");
    }
}
