using Microsoft.EntityFrameworkCore;
using WebApiCRUD.API.Data;
using WebApiCRUD.API.Domain.DTO.Difficulties;
using WebApiCRUD.API.Domain.Entity;
using WebApiCRUD.API.Repositories.Interfaces;

namespace WebApiCRUD.API.Repositories.Classes;

public class DifficultyRepository : IDifficultyRepository
{
    private readonly ApplicationDbContext _context;

    public DifficultyRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Difficulty> CreateAsync(Difficulty difficulty)
    {
        await _context.AddAsync(difficulty);
        await _context.SaveChangesAsync();
        return difficulty;
    }

    public async Task<Difficulty?> DeleteAsync(Guid id)
    {
        var difficulty = await _context.Difficulties.FirstOrDefaultAsync(x => x.Id == id);
        if (difficulty == null) 
            return null;

        _context.Difficulties.Remove(difficulty);
        await _context.SaveChangesAsync();
        return difficulty;
    }

    public async Task<List<Difficulty>> GetAllAsync()
    {
        return await _context.Difficulties.ToListAsync();        
    }

    public async Task<Difficulty?> GetByIdAsync(Guid id)
    {
        return await _context.Difficulties.FirstOrDefaultAsync(_ => _.Id == id);    
    }

    public async Task<Difficulty?> UpdateAsync(Guid id, UpdateDifficultyDTO difficulty)
    {
        var Resultdifficulty = await _context.Difficulties.FirstOrDefaultAsync(x => x.Id == id);

        if (Resultdifficulty == null)
            return null;
        Resultdifficulty.Name = difficulty.Name;

        await _context.SaveChangesAsync();

        return Resultdifficulty;

    }
}
