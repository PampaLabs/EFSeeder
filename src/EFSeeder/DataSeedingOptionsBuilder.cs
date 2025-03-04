using System.Reflection;

namespace EFSeeder;

/// <summary>
/// Provides a simple API surface for configuring <see cref="DataSeedingOptions" />.
/// </summary>
public class DataSeedingOptionsBuilder
{
    /// <summary>
    /// Gets the options being configured.
    /// </summary>
    public DataSeedingOptions Options { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSeedingOptionsBuilder" /> class with no options set.
    /// </summary>
    public DataSeedingOptionsBuilder() : this(new ())
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSeedingOptionsBuilder" /> class to further configure a given <see cref="DataSeedingOptions" />.
    /// </summary>
    /// <param name="options">The options to be configured.</param>
    public DataSeedingOptionsBuilder(DataSeedingOptions options)
    {
        Options = options;
    }

    /// <summary>
    /// Sets activator of the data seeders.
    /// </summary>
    /// <param name="activator">The activator of the data seeders.</param>
    public DataSeedingOptionsBuilder UseActivator(IDataSeederActivator activator)
    {
        Options.Activator = activator;
        return this;
    }

    /// <summary>
    /// Sets assembly of the data seeders.
    /// </summary>
    /// <param name="assembly">The assembly of the data seeders.</param>
    public DataSeedingOptionsBuilder DataSeedersAssembly(Assembly assembly)
    {
        Options.Assembly = assembly;
        return this;
    }
}