using AutoMapper;
using WebApiCRUD.API.Domain.DTO.Regions;
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
    }
}
