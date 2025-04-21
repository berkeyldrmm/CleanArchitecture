using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Dtos.EntityDtos.Car;

public class CarListingDTO : EntityDTO
{
    public string Name { get; set; }
    public string Model { get; set; }
}
