using WebApiCRUD.API.Domain.DTO.Difficulties;
using WebApiCRUD.API.Domain.Entity;

namespace WebApiCRUD.API.Repositories.Interfaces;

public interface IDifficultyRepository
{
    Task<List<Difficulty>> GetAllAsync();
    Task<Difficulty?> GetByIdAsync(Guid id);
    Task<Difficulty> CreateAsync(Difficulty difficulty);
    Task<Difficulty?> UpdateAsync(Guid id, UpdateDifficultyDTO difficulty);
    Task<Difficulty?> DeleteAsync(Guid id);
}
