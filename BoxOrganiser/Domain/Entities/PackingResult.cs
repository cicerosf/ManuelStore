namespace BoxOrganiser.API.Domain.Entities;

public class PackingResult
{
    public int OrderId { get; set; }
    public string Status => BoxResults.Any() ? "Success" : "No box available";
    public List<BoxResult> BoxResults { get; set; }
}
