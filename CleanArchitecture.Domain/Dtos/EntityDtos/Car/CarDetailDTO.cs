using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Dtos.EntityDtos.Car;

public class CarDetailDTO : EntityDTO
{
    public string Name { get; set; }
    public string Model { get; set; }
    public int EnginePower { get; set; }
}
