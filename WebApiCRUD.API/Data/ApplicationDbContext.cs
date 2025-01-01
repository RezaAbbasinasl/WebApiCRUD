using Microsoft.EntityFrameworkCore;
using WebApiCRUD.API.Domain.Entity;
using static System.Net.WebRequestMethods;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed data for Difficulties
        var difficulties = new List<Difficulty>
        {
            new Difficulty
            {
                Id = Guid.Parse("5a4f0398-b3d9-4ea2-83ae-f559ac721e31"),
                Name = "Easy"
            },
            new Difficulty
            {
                Id = Guid.Parse("d342f55b-fe02-4319-a6db-ac8f89869db2"),
                Name = "Medium"
            },
            new Difficulty
            {
                Id = Guid.Parse("bbfc77d5-ba2f-4080-a34d-1363189af83a"),
                Name = "Hard"
            }
        };
        modelBuilder.Entity<Difficulty>().HasData(difficulties);


        // Seed data for Region
        var regions = new List<Region>
        {
            new Region
            {
                Id = Guid.Parse("09085de6-8908-42b7-81f5-d439738a60ab"),
                Name = "Bay of plenty",
                Code = "BOP",
                RegionImageUrl = null
            },
            new Region
            {
                Id = Guid.Parse("c3acc73e-a87d-4c47-afb6-ad9c304f13a9"),
                Name = "Wellington",
                Code = "WGN",
                RegionImageUrl = "https://www.google.com/imgres?q=image&imgurl=https%3A%2F%2Fcdn.prod.website-files.com%2F62d84e447b4f9e7263d31e94%2F6399a4d27711a5ad2c9bf5cd_ben-sweet-2LowviVHZ-E-unsplash-1.jpeg&imgrefurl=https%3A%2F%2Fwww.pixsy.com%2Fimage-theft%2Fverify-image-source-copyright-owner&docid=XUAyne4_INagNM&tbnid=HXLlNEpHoJATkM&vet=12ahUKEwj8rd7p5sKKAxV71wIHHQk2DeYQM3oECGEQAA..i&w=1920&h=1080&hcb=2&ved=2ahUKEwj8rd7p5sKKAxV71wIHHQk2DeYQM3oECGEQAA"
            },
            new Region
            {
                Id = Guid.Parse("453b3e72-7991-4a4f-a3c4-0803f53da7b0"),
                Name = "Nelson",
                Code = "NSN",
                RegionImageUrl = "https://www.google.com/imgres?q=image&imgurl=https%3A%2F%2Fcreate.microsoft.com%2F_next%2Fimage%3Furl%3Dhttps%253A%252F%252Fdsgrcdnblobprod5u3.azureedge.net%252Fimages%252Fimage-creator-B03_mapletree.webp%26w%3D1920%26q%3D90&imgrefurl=https%3A%2F%2Fcreate.microsoft.com%2Fen-us%2Ffeatures%2Fai-image-generator&docid=5UlSeOv_qEH1jM&tbnid=fTlcbXO2uO_rDM&vet=12ahUKEwj8rd7p5sKKAxV71wIHHQk2DeYQM3oECGAQAA..i&w=1024&h=1024&hcb=2&itg=1&ved=2ahUKEwj8rd7p5sKKAxV71wIHHQk2DeYQM3oECGAQAA"
            }
        };
        modelBuilder.Entity<Region>().HasData(regions);
    }

}
