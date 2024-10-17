using BoxOrganiser.API.Application.Services;
using BoxOrganiser.API.Domain.Entities;
using BoxOrganiser.API.Domain.Interfaces;
using BoxOrganiser.API.Domain.ValueObjects;
using Moq;

namespace BoxOrganiser.Tests;

public class PackingServiceTests
{
    private readonly Mock<IBoxRepository> _mockBoxRepository;
    private readonly PackingService _packingService;

    public PackingServiceTests()
    {
        _mockBoxRepository = new Mock<IBoxRepository>();
        _packingService = new PackingService(_mockBoxRepository.Object);
    }

    [Fact]
    public void PackOrders_ShouldDistributeFourProductsIntoTwoBoxes()
    {
        // Arrange
        var boxes = new List<Box>
            {
                new Box("Box 1", new Dimensions(30, 40, 80)), // Volume: 96000
                new Box("Box 2", new Dimensions(80, 50, 40))  // Volume: 160000
            };

        var orders = new List<Order>
            {
                new Order(1, new List<Product>
                {
                    new Product("Product A", new Dimensions(10, 20, 30)), // Volume: 6000
                    new Product("Product B", new Dimensions(10, 20, 30)), // Volume: 6000
                    new Product("Product C", new Dimensions(20, 20, 20)), // Volume: 8000
                    new Product("Product D", new Dimensions(70, 40, 30))  // Volume: 9375
                })
            };

        _mockBoxRepository.Setup(x => x.GetAll()).Returns(boxes);

        // Act
        var result = _packingService.PackOrders(orders);

        // Assert
        Assert.Single(result);
        Assert.Equal(2, result[0].BoxResults.Count);
        Assert.Contains(result[0].BoxResults, br => br.BoxName == "Box 1");
        Assert.Contains(result[0].BoxResults, br => br.BoxName == "Box 2");
    }

    [Fact]
    public void PackOrders_ShouldNotFitProductInAnyBox()
    {
        // Arrange
        var boxes = new List<Box>
            {
                new Box("Box 1", new Dimensions(30, 40, 80)), // Volume: 96000
                new Box("Box 2", new Dimensions(80, 50, 40))  // Volume: 160000
            };

        var orders = new List<Order>
            {
                new Order(1, new List<Product>
                {
                    new Product("Product A", new Dimensions(100, 100, 100)) // Volume: 1000000
                })
            };

        _mockBoxRepository.Setup(x => x.GetAll()).Returns(boxes);

        // Act
        var result = _packingService.PackOrders(orders);

        // Assert
        Assert.Single(result);
        Assert.Equal(1, result[0].OrderId);
        Assert.Empty(result[0].BoxResults); // No box should be used
    }
}