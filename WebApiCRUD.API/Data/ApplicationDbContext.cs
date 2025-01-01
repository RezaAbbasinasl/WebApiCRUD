using Microsoft.EntityFrameworkCore;
using WebApiCRUD.API.Domain.Entity;

namespace WebApiCRUD.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Walk> Walks { get; set; }
    public DbSet<Region> Regions { get; set; }
    public DbSet<Difficulty> Difficulties { get; set; }
    public DbSet<FileEntity> FileEntities { get; set; }

}
