using Microsoft.EntityFrameworkCore;
using WebApiCRUD.API.Data;
using WebApiCRUD.API.Domain.DTO.Regions;
using WebApiCRUD.API.Domain.Entity;
using WebApiCRUD.API.Repositories.Interfaces;

namespace WebApiCRUD.API.Repositories.Classes;

public class RegionRepository : IRegionRepository
{
    private readonly ApplicationDbContext _dbContext;

    public RegionRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Region> CreateAsync(Region region)
    {
        await _dbContext.AddAsync(region);
        await _dbContext.SaveChangesAsync();
        return region;
    }

    public async Task<Region?> DeleteAsync(Guid id)
    {
        var region = await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); 
        if (region == null)
            return null;

        _dbContext.Regions.Remove(region);
        await _dbContext.SaveChangesAsync();

        return region;
    }

    public async Task<List<Region>> GetAllAsync()
    {
        return await _dbContext.Regions.ToListAsync();
    }

    public async Task<Region?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Region?> UpdateAsync(Guid id, UpdateRegionDTO region)
    {
        var existingRegion = await _dbContext.Regions.FirstOrDefaultAsync(y => y.Id == id);
        if(existingRegion == null)
            return null;

        existingRegion.Code = region.Code;
        existingRegion.RegionImageUrl = region.RegionImageUrl;
        existingRegion.Name = region.Name;

        await _dbContext.SaveChangesAsync();

        return existingRegion;
    }
}
