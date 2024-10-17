using BoxOrganiser.API.Domain.Entities;
using BoxOrganiser.API.Domain.Interfaces;

namespace BoxOrganiser.API.Application.Services;

public class PackingService : IPackingService
{
    private readonly IBoxRepository _boxRepository;

    public PackingService(IBoxRepository boxRepository)
    {
        _boxRepository = boxRepository;
    }

    public List<PackingResult> PackOrders(List<Order> orders)
    {
        var boxesAvailable = _boxRepository.GetAll().ToList();
        var results = new List<PackingResult>();

        foreach (var order in orders)
        {
            var boxUsage = new List<BoxResult>();

            foreach (var product in order.Products)
            {
                foreach (var box in boxesAvailable)
                {
                    if (box.Fits(product))
                    {
                        var existingBoxResult = boxUsage.FirstOrDefault(b => b.BoxName == box.Name);
                        if (existingBoxResult == null)
                        {
                            existingBoxResult = new BoxResult { BoxName = box.Name, Products = new List<string>() };
                            boxUsage.Add(existingBoxResult);
                        }
                        existingBoxResult.Products.Add(product.Name);

                        break;
                    }
                }
            }

            results.Add(new PackingResult
            {
                OrderId = order.Id,
                BoxResults = boxUsage
            });
        }

        return results;
    }
}