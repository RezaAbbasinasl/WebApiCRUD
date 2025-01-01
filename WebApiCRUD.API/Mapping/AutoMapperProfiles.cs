using AutoMapper;
using WebApiCRUD.API.Domain.DTO.Difficulties;
using WebApiCRUD.API.Domain.DTO.Regions;
using WebApiCRUD.API.Domain.DTO.Walks;
using WebApiCRUD.API.Domain.Entity;

namespace WebApiCRUD.API.Mapping;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        // Region
        CreateMap<Region, RegionDTO>().ReverseMap();
        CreateMap<Region, AddRegionDTO>().ReverseMap();
        CreateMap<RegionDTO, UpdateRegionDTO>().ReverseMap();

        // Walk
        CreateMap<Walk, WalkDTO>().ReverseMap();
        CreateMap<Walk, AddWalkDTO>().ReverseMap();
        CreateMap<WalkDTO, UpdateWalkDTO>().ReverseMap();

        // Difficulty
        CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
        CreateMap<Difficulty, AddDifficultyDTO>().ReverseMap();
        CreateMap<DifficultyDTO, UpdateDifficultyDTO>().ReverseMap();
    }
}
