using BoxOrganiser.API.Domain.ValueObjects;

namespace BoxOrganiser.API.Domain.Entities;

public class Product
{
    public string Name { get; private set; }
    public Dimensions Dimensions { get; private set; }

    public Product(string name, Dimensions dimensions)
    {
        Name = name;
        Dimensions = dimensions;
    }
}
