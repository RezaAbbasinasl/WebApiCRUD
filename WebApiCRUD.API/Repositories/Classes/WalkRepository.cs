using Microsoft.EntityFrameworkCore;
using WebApiCRUD.API.Data;
using WebApiCRUD.API.Domain.DTO.Walks;
using WebApiCRUD.API.Domain.Entity;
using WebApiCRUD.API.Repositories.Interfaces;

namespace WebApiCRUD.API.Repositories.Classes;

public class WalkRepository : IWalkRepository
{
    private readonly ApplicationDbContext _context;

    public WalkRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Walk> CreateAsync(Walk walk)
    {
        await _context.Walks.AddAsync(walk);
        await _context.SaveChangesAsync();
        return walk;
    }

    public async Task<Walk?> DeleteAsync(Guid id)
    {
        var walk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);
        if (walk != null)
        {
            _context.Walks.Remove(walk);
            await _context.SaveChangesAsync();
        }

        return walk;
    }

    public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100)
    {
        var walks = _context.Walks.Include(x => x.Difficulty).Include(x => x.Region).AsQueryable();

        // Filtering
        if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
        {
            if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }
        }

        // Sorting
        if (string.IsNullOrWhiteSpace(sortBy) == false)
        {
            if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            }
            else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
            {
                walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            }
        }

        // Pagination
        var skipResult = (pageNumber -1) * pageSize;

        return await walks.Skip(skipResult).Take(pageSize).ToListAsync();
    }

    public async Task<Walk?> GetByIcAsync(Guid id)
    {
        return await _context.Walks.Include(x => x.Difficulty).Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Walk?> UpdateAsync(Guid id, UpdateWalkDTO walk)
    {
        var walkResult = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);

        if (walk != null)
        {
            walkResult.Name = walk.Name;
            walkResult.Description = walk.Description;
            walkResult.LengthInKm = walk.LengthInKm;
            walkResult.WalksImageUrl = walk.WalksImageUrl;
            walkResult.DifficultyId = walk.DifficultyId;
            walkResult.RegionId = walk.RegionId;

            await _context.SaveChangesAsync();
        }

        return walkResult;
    }
}
