using CleanArchitecture.Application.Abstraction.AbstractHandlers;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Dtos.EntityDtos.Car;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetCarById;

public sealed class GetCarByIdQueryHandler : CarHandler, IRequestHandler<GetCarByIdQuery, DataResponse<CarDetailDTO>>
{
    public GetCarByIdQueryHandler(ICarService carService) : base(carService)
    {
    }

    public async Task<DataResponse<CarDetailDTO>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
    {
        return new(await _carService.GetCarById(request.Id));

    }
}
