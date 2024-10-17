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

    // Devido à complexidade da lógica de empacotamento, optei por uma abordagem simplificada,
    // baseado no volume dos produtos e das caixas.
    // O foco principal foi na estrutura e organização do código,
    public List<PackingResult> PackOrders(List<Order> orders)
    {
        var boxesAvailable = _boxRepository.GetAll().ToList();
        var results = new List<PackingResult>();

        foreach (var order in orders)
        {
            var boxUsage = new List<BoxResult>();

            foreach (var product in order.Products)
            {
                var productVolume = product.Dimensions.Volume;

                foreach (var box in boxesAvailable)
                {
                    var existingBoxResult = boxUsage.FirstOrDefault(b => b.BoxName == box.Name);
                    double totalVolumeInBox = 0;

                    if (existingBoxResult != null)
                    {
                        foreach (var productName in existingBoxResult.Products)
                        {
                            var productInBox = order.Products.FirstOrDefault(p => p.Name == productName);
                            totalVolumeInBox += productInBox.Dimensions.Volume;
                        }
                    }

                    if (box.Fits(totalVolumeInBox + productVolume))
                    {
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