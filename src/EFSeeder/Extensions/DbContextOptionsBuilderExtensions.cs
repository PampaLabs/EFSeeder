using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFSeeder;

/// <summary>
/// Extension methods for <see cref="DbContextOptionsBuilder" />
/// </summary>
public static class DbContextOptionsBuilderExtensions
{
#if NET9_0_OR_GREATER
    /// <summary>
    ///     Configures the seed method to run after <see cref="DatabaseFacade.EnsureCreatedAsync" />
    ///     is called or after migrations are applied asynchronously.
    ///     It will be invoked even if no changes to the store were performed.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <param name="optionsBuilder">The database context option builder.</param>
    /// <param name="seeder">The database seeder.</param>
    /// <returns></returns>
    public static DbContextOptionsBuilder UseAsyncSeeding<TContext>(this DbContextOptionsBuilder optionsBuilder, DbContextSeeder<TContext> seeder)
        where TContext : DbContext
    {
        optionsBuilder.UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            await (context as TContext)!.SeedAsync(seeder, cancellationToken);
        });

        return optionsBuilder;
    }

    /// <summary>
    ///     Configures the seed method to run after <see cref="DatabaseFacade.EnsureCreatedAsync" />
    ///     is called or after migrations are applied asynchronously.
    ///     It will be invoked even if no changes to the store were performed.
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    /// <param name="optionsBuilder">The database context option builder.</param>
    /// <param name="seeder">The database seeder.</param>
    /// <returns></returns>
    public static DbContextOptionsBuilder<TContext> UseAsyncSeeding<TContext>(this DbContextOptionsBuilder<TContext> optionsBuilder, DbContextSeeder<TContext> seeder)
        where TContext : DbContext
    {
        optionsBuilder.UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            await context.SeedAsync(seeder, cancellationToken);
        });

        return optionsBuilder;
    }
#endif
}