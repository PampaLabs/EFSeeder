using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

/// <summary>
/// Extension methods for <see cref="ModelBuilder" />
/// </summary>
public static class ModelBuilderExtensions
{
    /// <summary>
    /// Configures the model to use data seeder history.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    /// <returns>The same builder instance so that multiple calls can be chained.</returns>
    public static ModelBuilder UseDataSeeder(this ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfiguration(new DataSeederHistoryConfiguration());
}