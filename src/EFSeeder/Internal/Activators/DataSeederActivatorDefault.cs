namespace EFSeeder;

/// <summary>
/// Default implementation of <see cref="IDataSeederActivator" />.
/// </summary>
internal class DataSeederActivatorDefault : IDataSeederActivator
{
    /// <inheritdoc />
    public object? CreateInstance(Type instanceType)
        => Activator.CreateInstance(instanceType);
}