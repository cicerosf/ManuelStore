using BoxOrganiser.API.Domain.ValueObjects;

namespace BoxOrganiser.API.Domain.Entities;

public class Box
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public Dimensions Dimensions { get; private set; }

    public Box(string name, Dimensions dimensions)
    {
        Id = Guid.NewGuid();
        Name = name;
        Dimensions = dimensions;
    }

    public bool Fits(Product product)
    {
        return product.Dimensions.Height <= Dimensions.Height &&
               product.Dimensions.Width <= Dimensions.Width &&
               product.Dimensions.Length <= Dimensions.Length;
    }
}
