using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection;

namespace EFSeeder;

internal static class DataSeederRegistral
{
    public static IDataSeederCollection AddFromAssembly<TContext>(this IDataSeederCollection seeders, Assembly assembly)
        where TContext : DbContext
    {
        var sortedList = new SortedList<string, DataSeederDescriptor>();

        var dataSeederType = typeof(IDataSeeder<>);

        bool HasInterface(Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == dataSeederType;

        var seederTypes = assembly.GetExportedTypes().Where(t => t.GetInterfaces().Any(HasInterface));

        foreach (var seederType in seederTypes)
        {
            var contextAttr = seederType.GetCustomAttribute<DbContextAttribute>();
            var seederAttr = seederType.GetCustomAttribute<DataSeederAttribute>();

            if (contextAttr is not null && seederAttr is not null)
            {
                if (contextAttr.ContextType == typeof(TContext))
                {
                    var descriptor = new DataSeederDescriptor(contextAttr.ContextType, seederAttr.Id, seederType);
                    sortedList.Add(seederAttr.Id, descriptor);
                }
            }
        }

        foreach (var item in sortedList)
        {
            seeders.Add(item.Value);
        }

        return seeders;
    }
}