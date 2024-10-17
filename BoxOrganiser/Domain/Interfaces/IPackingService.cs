using BoxOrganiser.API.Domain.Entities;

namespace BoxOrganiser.API.Domain.Interfaces;

public interface IPackingService
{
    List<PackingResult> PackOrders(List<Order> orders);
}