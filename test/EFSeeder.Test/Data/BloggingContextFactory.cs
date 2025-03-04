using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using EFSeeder.Test.Data;

public class BloggingContextFactory : IDesignTimeDbContextFactory<BloggingContext>
{
    public BloggingContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BloggingContext>();
        optionsBuilder.UseSqlServer();

        return new BloggingContext(optionsBuilder.Options);
    }
}