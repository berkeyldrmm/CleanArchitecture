using AutoMapper;
using CleanArchitecture.Application.Features.AuthFeatures.Commands.Register;
using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Dtos.EntityDtos.Car;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Persistance.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateCarCommand, Car>();
        CreateMap<Car, CarDetailDTO>().ReverseMap();
        CreateMap<Car, CarListingDTO>().ReverseMap();

        CreateMap<RegisterCommand, User>().ReverseMap();
    }
}
