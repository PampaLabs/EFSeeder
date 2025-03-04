using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

/// <summary>
/// Specifies the contract for a data seeder.
/// </summary>
/// <typeparam name="TContext">Type of <see cref="DbContext" />.</typeparam>
public interface IDataSeeder<in TContext>
    where TContext : DbContext
{
    /// <summary>
    /// Performs the data seeding operation on the database.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="cancellationToken">>A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns></returns>
    Task SeedAsync(TContext context, CancellationToken cancellationToken = default);
}

/// <summary>
/// Specifies the contract for a data seeder.
/// </summary>
public interface IDataSeeder : IDataSeeder<DbContext>
{
}