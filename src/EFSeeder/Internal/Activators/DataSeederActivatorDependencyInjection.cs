using Microsoft.Extensions.DependencyInjection;

namespace EFSeeder;

/// <summary>
/// Dependency injection implementation of <see cref="IDataSeederActivator" />.
/// </summary>
internal class DataSeederActivatorDependencyInjection(IServiceProvider serviceProvider) : IDataSeederActivator
{
    /// <inheritdoc />
    public object? CreateInstance(Type instanceType)
        => ActivatorUtilities.CreateInstance(serviceProvider, instanceType);
}