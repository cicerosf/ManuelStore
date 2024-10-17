namespace BoxOrganiser.API.Domain.ValueObjects;

public class Dimensions
{
    public int Height { get; private set; }
    public int Width { get; private set; }
    public int Length { get; private set; }

    public Dimensions(int height, int width, int length)
    {
        Height = height;
        Width = width;
        Length = length;
    }
}
