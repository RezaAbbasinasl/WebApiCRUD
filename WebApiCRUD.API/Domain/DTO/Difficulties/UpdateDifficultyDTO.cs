using System.ComponentModel.DataAnnotations;

namespace WebApiCRUD.API.Domain.DTO.Difficulties
{
    public class UpdateDifficultyDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
