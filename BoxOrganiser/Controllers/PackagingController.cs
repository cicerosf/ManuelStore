using BoxOrganiser.API.Domain.Entities;
using BoxOrganiser.API.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoxOrganiser.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PackagingController : ControllerBase
{
    private readonly IPackingService _packingService;

    public PackagingController(IPackingService orderService)
    {
        _packingService = orderService;
    }

    [HttpPost("PackOrders")]
    public ActionResult<List<PackingResult>> PackOrders(List<Order> orders)
    {
        var result = _packingService.PackOrders(orders);

        return Ok(result);
    }
}