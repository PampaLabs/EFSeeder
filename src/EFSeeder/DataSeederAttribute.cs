namespace EFSeeder;

/// <summary>
/// Indicates that a class is a <see cref="IDataSeeder{TContext}" /> and provides its identifier.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class DataSeederAttribute : Attribute
{
    /// <summary>
    /// Creates a new instance of this attribute.
    /// </summary>
    /// <param name="id">The data seeder identifier.</param>
    public DataSeederAttribute(string id)
    {
        Id = id;
    }

    /// <summary>
    /// The data seeder identifier.
    /// </summary>
    public string Id { get; }
}