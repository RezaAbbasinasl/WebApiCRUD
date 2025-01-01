using WebApiCRUD.API.Domain.Entity;

namespace WebApiCRUD.API.Domain.DTO.Walks;

public class WalkDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double LengthInKm { get; set; }
    public string? WalksImageUrl { get; set; }

    public Region Region { get; set; }
    public Difficulty Difficulty { get; set; }
}
