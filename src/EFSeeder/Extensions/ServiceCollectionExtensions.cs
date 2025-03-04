using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EFSeeder;

/// <summary>
/// Extension methods for <see cref="IServiceCollection" />
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers data seeding services.
    /// </summary>
    /// <typeparam name="TContext">Type of <see cref="DbContext" />.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="optionsAction">An action to configure the <see cref="DataSeedingOptions" />.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection AddDbContextSeeder<TContext>(this IServiceCollection services, Action<DataSeedingOptionsBuilder> optionsAction)
        where TContext : DbContext
    {
        services.AddScoped(serviceProvider => {
            var activator = DataSeederActivator.DependencyInjection(serviceProvider);

            var optionsBuilder = new DataSeedingOptionsBuilder().UseActivator(activator);
            optionsAction?.Invoke(optionsBuilder);

            return new DbContextSeeder<TContext>(optionsBuilder.Options);
        });

        return services;
    }

    /// <summary>
    /// Registers data seeding services.
    /// </summary>
    /// <typeparam name="TContext">Type of <see cref="DbContext" />.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="optionsAction">An action to configure the <see cref="DataSeedingOptions" />.</param>
    /// <returns>The same service collection so that multiple calls can be chained.</returns>
    public static IServiceCollection AddDbContextSeeder<TContext>(this IServiceCollection services, Action<IServiceProvider,DataSeedingOptionsBuilder> optionsAction)
        where TContext : DbContext
    {
        services.AddScoped(serviceProvider => {
            var activator = DataSeederActivator.DependencyInjection(serviceProvider);

            var optionsBuilder = new DataSeedingOptionsBuilder().UseActivator(activator);
            optionsAction?.Invoke(serviceProvider, optionsBuilder);

            return new DbContextSeeder<TContext>(optionsBuilder.Options);
        });

        return services;
    }
}