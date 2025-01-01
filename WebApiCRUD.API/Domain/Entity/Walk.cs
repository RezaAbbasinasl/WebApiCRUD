namespace WebApiCRUD.API.Domain.Entity;

public class Walk
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double LengthInKm { get; set; }
    public string? WalksImageUrl { get; set; }
    public Guid RegionId { get; set; }
    public Guid DifficultyId { get; set; }

    public Region Region { get; set; }
    public Difficulty Difficulty { get; set; }
}
