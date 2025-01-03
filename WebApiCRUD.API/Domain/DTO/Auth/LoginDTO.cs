using System.ComponentModel.DataAnnotations;

namespace WebApiCRUD.API.Domain.DTO.Auth;

public class LoginDTO
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string UserName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
