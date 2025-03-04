using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

/// <summary>
/// Extension methods for <see cref="DataSeedingOptions" />
/// </summary>
public static class DataSeedingOptionsExtensions
{
    /// <summary>
    /// Creates a new instance of <see cref="DataSeedingOptions{TContext}"/> based on the provided <see cref="DataSeedingOptions"/>.
    /// </summary>
    /// <typeparam name="TContext">The type of the <see cref="DbContext"/> to associate with the seeding options.</typeparam>
    /// <param name="options">The base <see cref="DataSeedingOptions"/> to copy settings from.</param>
    /// <returns>A new instance of <see cref="DataSeedingOptions{TContext}"/> with the copied settings.</returns>
    public static DataSeedingOptions<TContext> Of<TContext>(this DataSeedingOptions options)
        where TContext : DbContext
    {
        return new DataSeedingOptions<TContext>()
        {
            Activator = options.Activator,
            Assembly = options.Assembly,
        };
    }
}