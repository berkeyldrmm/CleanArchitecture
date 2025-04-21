using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Domain.Dtos.EntityDtos.Car;
using MediatR;

namespace CleanArchitecture.Application.Features.CarFeatures.Queries.GetAllCars;

public sealed record GetAllCarsQuery(int pageSize = 10, int pageNumber = 1) : IRequest<PagedListDataResponse<CarListingDTO>>;