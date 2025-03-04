using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFSeeder.Test.Data.DataSeeders;

[DbContext(typeof(BloggingContext))]
[DataSeeder("00000000000000_InitialSeed")]
public class InitialSeed : IDataSeeder<BloggingContext>
{
    public async Task SeedAsync(BloggingContext context, CancellationToken cancellationToken = default)
    {
        await context.Blogs.AddAsync(new Blog { Url = "http://blogs.msdn.com/adonet" });

        await context.SaveChangesAsync();
    }
}