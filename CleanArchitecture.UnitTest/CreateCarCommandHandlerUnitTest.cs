using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Dtos;
using Moq;

namespace CleanArchitecture.UnitTest;

public class CreateCarCommandHandlerUnitTest
{
    [Fact]
    public async Task Handle_ReturnsSuccessMessage_WhenCarIsCreatedSuccessfully()
    {
        //Arrange
        var carServiceMock = new Mock<ICarService>();
        MessageResponse response = new("Car has been saved successfully!");

        CreateCarCommand request = new("Toyota", "Corolla", 75);
        CancellationToken cancellationToken = new();

        carServiceMock.Setup(c => c.CreateCar(request, cancellationToken))
            .Returns(Task.FromResult(true));

        CreateCarCommandHandler createCarCommandHandler = new(carServiceMock.Object);

        //Act
        MessageResponse result = await createCarCommandHandler.Handle(request, cancellationToken);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<MessageResponse>(result);
        Assert.Equal(response, result);
        Assert.Equal("Car has been saved successfully!", result.Message);

        carServiceMock.Verify(c=>c.CreateCar(request, cancellationToken), Times.Once);
    }
}
