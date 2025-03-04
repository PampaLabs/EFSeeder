# EFSeeder

[![CI](https://github.com/PampaLabs/EFSeeder/actions/workflows/ci.yml/badge.svg)](https://github.com/PampaLabs/EFSeeder/actions/workflows/ci.yml)
[![Downloads](https://img.shields.io/nuget/dt/EFSeeder)](https://www.nuget.org/stats/packages/EFSeeder?groupby=Version)
[![NuGet](https://img.shields.io/nuget/v/EFSeeder)](https://www.nuget.org/packages/EFSeeder/)

EFSeeder is an extension for Entity Framework Core that provides a simple and flexible way to seed data into your database. It provides out-of-the-box idempotency.

## Installation

To install EFSeeder, add the following package reference to your project:

```bash
dotnet add package EFSeeder
```

## Usage

### Defining the `DbContext`

To enable data seeding, you first need to configure your DbContext. This is done by overriding the `OnModelCreating` method and calling `UseDataSeeder()` within it.

```csharp
public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options) { }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.UseDataSeeder();
    }
}
```

### Defining a Data Seeder

To define one, create a class that implements `IDataSeeder<TContext>`. Use the `DataSeederAttribute` to provide a unique identifier for the seeder.

```csharp
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace YourNamespace.DataSeeders;

[DbContext(typeof(BloggingContext))]
[DataSeeder("00000000000000_InitialSeed")]
public class InitialSeed : IDataSeeder<BloggingContext>
{
    public async Task SeedAsync(BloggingContext context, CancellationToken cancellationToken = default)
    {
        await context.Blogs.AddAsync(new Blog { Url = "http://blogs.msdn.com/adonet" });

        await context.SaveChangesAsync();
    }
}
```

### Configuring the Data Seeder

To enable data seeding, you need to configure the data seeder when registering services in the dependency injection container. This tells the application where to look for seeders.

Next, configure the DbContext to use data seeding along with your database provider.

```csharp
builder.Services.AddDbContextSeeder<BloggingContext>(options =>
{
    options.DataSeedersAssembly(typeof(BloggingContext).Assembly);
});

builder.Services.AddDbContext<BloggingContext>((serviceProvider, options) =>
{
    var seeder = serviceProvider.GetRequiredService<DbContextSeeder<BloggingContext>>();

    options
        .UseSqlServer("YourConnectionString")
        .UseAsyncSeeder(seeder);
});
```

or before .NET 9

```csharp
builder.Services.AddDbContextSeeder<BloggingContext>(options =>
{
    options.DataSeedersAssembly(typeof(BloggingContext).Assembly);
});

builder.Services.AddDbContext<BloggingContext>(options =>
{
    options.UseSqlServer("YourConnectionString");
});
```

### Running the Data Seeder

Once everything is configured, you need to ensure that the database is up to date and apply the seed data. This is done by calling `MigrateAsync()` on the `DbContext`.

```csharp
var dbContext = serviceProvider.GetRequiredService<BloggingContext>();

await dbContext.Database.MigrateAsync();
```

or before .NET 9

```csharp
var dbContext = serviceProvider.GetRequiredService<BloggingContext>();
var seeder = serviceProvider.GetRequiredService<DbContextSeeder<BloggingContext>>();

await dbContext.Database.MigrateAsync();
await dbContext.SeedAsync(seeder);
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request on GitHub.
