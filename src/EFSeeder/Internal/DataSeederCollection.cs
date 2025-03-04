namespace EFSeeder;

/// <summary>
/// Specifies the contract for a collection of data seeder descriptors.
/// </summary>
internal interface IDataSeederCollection : IList<DataSeederDescriptor>
{
}

/// <summary>
/// Default implementation of <see cref="IDataSeederCollection" />.
/// </summary>
internal class DataSeederCollection : List<DataSeederDescriptor>, IDataSeederCollection
{
}
