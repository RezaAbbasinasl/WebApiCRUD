﻿using System.ComponentModel.DataAnnotations;

namespace WebApiCRUD.API.Domain.DTO.Regions;

public class AddRegionDTO
{
    [Required]
    [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
    [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
    public string Code { get; set; }
    [Required]
    [MaxLength(100, ErrorMessage = "Name has to be a maximum of 3 characters")]
    public string Name { get; set; }
    public string? RegionImageUrl { get; set; }
}
