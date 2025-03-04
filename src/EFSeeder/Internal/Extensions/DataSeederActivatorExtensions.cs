using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

internal static class DataSeederActivatorExtensions
{
    public static IDataSeeder<TContext> CreateInstance<TContext>(this IDataSeederActivator activator, Type seederType)
        where TContext : DbContext
    {
        return (IDataSeeder<TContext>)activator.CreateInstance(seederType)!;
    }
}