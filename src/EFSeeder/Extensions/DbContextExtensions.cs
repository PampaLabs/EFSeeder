using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

/// <summary>
/// Extension methods for <see cref="DbContext" />
/// </summary>
public static class DbContextExtensions
{
    /// <summary>
    /// Applies any pending data seeders for the context to the database.
    /// </summary>
    /// <typeparam name="TContext">Type of <see cref="DbContext" />.</typeparam>
    /// <param name="dbContext">The database context.</param>
    /// <param name="seeder">The database seeder.</param>
    /// <param name="cancellationToken">>A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns>A task that represents the asynchronous migration operation.</returns>
    public static async Task SeedAsync<TContext>(this TContext dbContext, DbContextSeeder<TContext> seeder, CancellationToken cancellationToken = default)
        where TContext : DbContext
    {
        await seeder.RunAsync(dbContext, cancellationToken);
    }
}