using WebApiCRUD.API.Domain.DTO.Regions;
using WebApiCRUD.API.Domain.Entity;

namespace WebApiCRUD.API.Repositories.Interfaces;

public interface IRegionRepository
{
    Task<List<Region>> GetAllAsync();
    Task<Region?> GetByIdAsync(Guid id);
    Task<Region> CreateAsync(Region region);
    Task<Region?> UpdateAsync(Guid id, UpdateRegionDTO region);
    Task<Region?> DeleteAsync(Guid id);
}
