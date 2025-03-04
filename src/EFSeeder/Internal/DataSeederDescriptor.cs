namespace EFSeeder;

/// <summary>
/// Describes a seeder with its id, and implementation.
/// </summary>
internal class DataSeederDescriptor
{
    /// <summary>
    /// Gets the type of the database context.
    /// </summary>
    public Type ContextType { get; }

    /// <summary>
    /// Gets the id of the seeder.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the type of the seeder.
    /// </summary>
    public Type SeederType { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="DataSeederDescriptor" />
    /// </summary>
    /// <param name="contextType">The type of the database context.</param>
    /// <param name="id">The id of the seeder.</param>
    /// <param name="seederType">The type of the seeder.</param>
    public DataSeederDescriptor(Type contextType, string id, Type seederType)
    {
        Id = id;
        SeederType = seederType;
        ContextType = contextType;
    }
}
