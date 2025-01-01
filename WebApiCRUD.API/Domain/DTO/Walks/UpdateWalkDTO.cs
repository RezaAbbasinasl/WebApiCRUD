using System.ComponentModel.DataAnnotations;

namespace WebApiCRUD.API.Domain.DTO.Walks;

public class UpdateWalkDTO
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(1000)]
    public string Description { get; set; }
    [Required]
    [Range(0, 50)]
    public double LengthInKm { get; set; }
    public string? WalksImageUrl { get; set; }
    [Required]
    public Guid RegionId { get; set; }
    [Required]
    public Guid DifficultyId { get; set; }
}
