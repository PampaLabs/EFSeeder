using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

/// <summary>
/// Execution unit for database seeding operations.
/// </summary>
/// <typeparam name="TContext">Type of <see cref="DbContext" />.</typeparam>
public class DbContextSeeder<TContext>
    where TContext : DbContext
{
    private readonly DataSeedingOptions _options;

    /// <summary>
    /// Initializes a new instance of <see cref="DbContextSeeder{TContext}" />
    /// </summary>
    public DbContextSeeder(DataSeedingOptions options)
    {
        _options = options;
    }

    /// <summary>
    /// Runs the database seeding operations.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="cancellationToken">>A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
    /// <returns></returns>
    public async Task RunAsync(TContext context, CancellationToken cancellationToken = default)
    {
        var seeders = new DataSeederCollection();
        seeders.AddFromAssembly<TContext>(_options.Assembly);
        
        foreach (var seeder in seeders)
        {
            if (cancellationToken.IsCancellationRequested) break;

            await RunAsync(context, seeder, cancellationToken);
        }
    }

    private async Task RunAsync(TContext context, DataSeederDescriptor descriptor, CancellationToken cancellationToken = default)
    {
        var runner = new DataSeederRunner<TContext>(context);
        await runner.RunAsync(descriptor.Id, () => CreateSeeder(descriptor), cancellationToken);
    }

    private IDataSeeder<TContext> CreateSeeder(DataSeederDescriptor descriptor)
        => _options.Activator.CreateInstance<TContext>(descriptor.SeederType);
}