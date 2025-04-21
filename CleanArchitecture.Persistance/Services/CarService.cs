using AutoMapper;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCars;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Dtos.EntityDtos.Car;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Domain.Repository;
using CleanArchitecture.Persistance.Pagination;

namespace CleanArchitecture.Persistance.Services;

public class CarService : ICarService
{
    public ICarRepository _carRepository;
    public IUnitOfWork _unitOfWork;
    public IMapper _mapper { get; set; }
    public CarService(IMapper mapper, ICarRepository carRepository, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _carRepository = carRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> CreateCar(CreateCarCommand request, CancellationToken cancellationToken)
    {
        Car car = _mapper.Map<Car>(request);

        bool addResult = await _carRepository.AddAsync(car, cancellationToken);
        int saveResult = await _unitOfWork.SaveChangesAsync();

        return addResult && saveResult > 0;
    }

    public async Task<PagedListDataResponse<CarListingDTO>> GetAllCars(GetAllCarsQuery request)
    {
        return await _carRepository.GetAll<CarListingDTO>().PagedListResponse(request.pageSize, request.pageNumber);
    }

    public async Task<CarDetailDTO> GetCarById(string id)
    {
        return await _carRepository.GetOneAsync<CarDetailDTO>(id);
    }
}
