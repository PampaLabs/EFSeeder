using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

/// <summary>
/// The options to be used for data seeding.
/// </summary>
public class DataSeedingOptions
{
    /// <summary>
    /// Gets the seeder activator.
    /// </summary>
    public IDataSeederActivator Activator { get; internal set; }

    /// <summary>
    /// Gets the seeder assembly.
    /// </summary>
    public Assembly Assembly { get; internal set; }

    /// <summary>
    /// Initializes a new instance of <see cref="DataSeedingOptions" />
    /// </summary>
    public DataSeedingOptions()
    {
        Activator = DataSeederActivator.Default();
        Assembly = Assembly.GetEntryAssembly()!;
    }
}