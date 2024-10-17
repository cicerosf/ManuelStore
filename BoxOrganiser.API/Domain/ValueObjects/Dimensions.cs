using BoxOrganiser.API.Domain.Exceptions;

namespace BoxOrganiser.API.Domain.ValueObjects;

public class Dimensions
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    public int Length { get; private set; }
    public double Volume => Height * Width * Length;

    public Dimensions(int height, int width, int length)
    {
        if (height <= 0 || width <= 0 || length <= 0)
        {
            throw new DomainException("Dimensions must be greater than zero.");
        }

        Height = height;
        Width = width;
        Length = length;
    }
}
