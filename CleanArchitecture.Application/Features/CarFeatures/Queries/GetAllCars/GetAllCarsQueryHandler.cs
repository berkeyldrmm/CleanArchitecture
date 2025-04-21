using CleanArchitecture.Application.Abstraction.AbstractHandlers;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Dtos.EntityDtos.Car;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCars;

public sealed class GetAllCarsQueryHandler : CarHandler, IRequestHandler<GetAllCarsQuery, PagedListDataResponse<CarListingDTO>>
{
    public GetAllCarsQueryHandler(ICarService carService) : base(carService)
    {
    }

    public async Task<PagedListDataResponse<CarListingDTO>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
    {
        return await _carService.GetAllCars(request);
    }
}
