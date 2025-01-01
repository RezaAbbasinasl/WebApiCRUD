using System.ComponentModel.DataAnnotations;

namespace WebApiCRUD.API.Domain.DTO.Difficulties;

public class AddDifficultyDTO
{
    [Required]
    public string Name{ get; set; }
}
