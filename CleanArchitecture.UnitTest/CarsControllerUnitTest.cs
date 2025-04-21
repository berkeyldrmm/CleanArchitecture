using CleanArchitecture.Application.Features.CarFeatures.Commands.CreateCar;
using CleanArchitecture.Domain.Dtos;
using CleanArchitecture.Presentation.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitecture.UnitTest;

public class CarsControllerUnitTest
{
    [Fact]
    public async Task Create_ReturnsOkResult_WhenRequestIsValid()
    {
        //Arrange
        Mock<IMediator> mediatorMock = new Mock<IMediator>();
        MessageResponse response = new("Car has been saved successfully!");

        CreateCarCommand request = new("Toyota", "Corolla", 75);
        CancellationToken cancellationToken = new();

        mediatorMock.Setup(m => m.Send(request, cancellationToken))
            .ReturnsAsync(response);

        CarsController carsController = new(mediatorMock.Object);

        //Act
        IActionResult result = await carsController.Create(request, cancellationToken);

        //Assert
        OkObjectResult? okResult = Assert.IsType<OkObjectResult>(result);
        MessageResponse? returnValue = Assert.IsType<MessageResponse>(okResult.Value);

        Assert.Equal(returnValue, response);

        mediatorMock.Verify(m => m.Send(request, cancellationToken), Times.Once);
    }
}
