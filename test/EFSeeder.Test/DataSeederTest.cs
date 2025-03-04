using EFSeeder.Test.Data;

using Microsoft.EntityFrameworkCore;

namespace EFSeeder.Test;

public class DataSeederTest : MsSqlServerContainerTest
{
    [Fact]
    public async Task Seed_InitialSeed_CreatesOneBlog()
    {
        var seedingOptions = new DataSeedingOptionsBuilder()
            .DataSeedersAssembly(typeof(BloggingContext).Assembly)
            .Options;

        var seeder = new DbContextSeeder<BloggingContext>(seedingOptions);

        var dbContextOptions = new DbContextOptionsBuilder<BloggingContext>()
            .UseSqlServer(MsSqlContainer.GetConnectionString(), options =>
                options.MigrationsAssembly(typeof(BloggingContext).Assembly.FullName)
            )
            .UseAsyncSeeding(seeder)
            .Options;

        var dbContext = new BloggingContext(dbContextOptions);

        await dbContext.Database.MigrateAsync();
        dbContext.Blogs.Count().Should().Be(1);

        await dbContext.Database.MigrateAsync();
        dbContext.Blogs.Count().Should().Be(1);
    }
}