namespace EFSeeder;

/// <summary>
/// Catalog of data seeder activators
/// </summary>
public static class DataSeederActivator
{
    /// <summary>
    /// Default
    /// </summary>
    /// <returns>Instance of <see cref="IDataSeederActivator" /></returns>
    public static IDataSeederActivator Default()
        => new DataSeederActivatorDefault();

    /// <summary>
    /// Dependency injection
    /// </summary>
    /// <returns>Instance of <see cref="IDataSeederActivator" /></returns>
    public static IDataSeederActivator DependencyInjection(IServiceProvider serviceProvider)
        => new DataSeederActivatorDependencyInjection(serviceProvider);
}