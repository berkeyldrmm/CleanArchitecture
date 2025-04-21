using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCars;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Dtos.EntityDtos.Car;

namespace CleanArchitecture.Application.Services;

public interface ICarService
{
    Task<bool> CreateCar(CreateCarCommand request, CancellationToken cancellationToken);
    Task<PagedListDataResponse<CarListingDTO>> GetAllCars(GetAllCarsQuery request);
    Task<CarDetailDTO> GetCarById(string id);
}
