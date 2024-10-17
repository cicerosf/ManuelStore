namespace BoxOrganiser.API.Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public List<Product> Products { get; set; }

    public Order(int id, List<Product> products)
    {
        Id = id;
        Products = products;
    }
}
