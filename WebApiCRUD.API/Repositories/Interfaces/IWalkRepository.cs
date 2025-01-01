using WebApiCRUD.API.Domain.DTO.Walks;
using WebApiCRUD.API.Domain.Entity;

namespace WebApiCRUD.API.Repositories.Interfaces;

public interface IWalkRepository
{
    Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 100);
    Task<Walk> CreateAsync(Walk walk);
    Task<Walk?> UpdateAsync(Guid id, UpdateWalkDTO walk);
    Task<Walk?> DeleteAsync(Guid id);
    Task<Walk?> GetByIcAsync(Guid id);
}
