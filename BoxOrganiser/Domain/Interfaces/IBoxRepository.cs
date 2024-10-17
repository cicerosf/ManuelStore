using BoxOrganiser.API.Domain.Entities;

namespace BoxOrganiser.API.Domain.Interfaces;

public interface IBoxRepository
{
    IEnumerable<Box> GetAll();
}