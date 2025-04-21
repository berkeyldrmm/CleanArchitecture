using CleanArchitecture.Application.Services;

namespace CleanArchitecture.Application.Abstraction.AbstractHandlers;

public abstract class CarHandler
{
    public ICarService _carService;

    protected CarHandler(ICarService carService)
    {
        _carService = carService;
    }
}
