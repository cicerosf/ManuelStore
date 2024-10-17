using BoxOrganiser.API.Domain.Entities;
using BoxOrganiser.API.Domain.Interfaces;
using BoxOrganiser.API.Domain.ValueObjects;

namespace BoxOrganiser.API.Infrastructure.Repositories;

public class BoxRepository : IBoxRepository
{
    // Fake DB
    private readonly List<Box> _boxes = new List<Box>
    {
        new Box("Box 1", new Dimensions(30, 40, 80)),
        new Box("Box 2", new Dimensions(80, 50, 40)),
        new Box("Box 3", new Dimensions(50, 80, 60))
    };

    public IEnumerable<Box> GetAll()
    {
        return _boxes;
    }
}
