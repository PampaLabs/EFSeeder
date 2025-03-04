namespace EFSeeder;

/// <summary>
/// Specifies the contract for a data seeder activator.
/// </summary>
public interface IDataSeederActivator
{
    /// <summary>
    /// Creates an instance of the spacified type.
    /// </summary>
    /// <param name="instanceType">The type of the instance.</param>
    /// <returns>An activated object of type instanceType.</returns>
    object? CreateInstance(Type instanceType);
}
