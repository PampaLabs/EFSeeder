using Microsoft.EntityFrameworkCore;

namespace EFSeeder;

internal class DataSeederRunner<TContext>
    where TContext : DbContext
{
    private readonly TContext _context;

    public DataSeederRunner(TContext context)
    {
        _context = context;
    }

    public async Task RunAsync(string id, Func<IDataSeeder<TContext>> seederFactory, CancellationToken cancellationToken = default)
    {
        var history = _context.Set<DataSeederHistory>();
        
        var exists = history.Any(h => h.DataSeederId == id);
        if (exists) return;

        var seeder = seederFactory();

        if (_context.Database.CurrentTransaction is null)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(CancellationToken.None);

            await ExecuteSeeder(cancellationToken);

            if (cancellationToken.IsCancellationRequested)
            {
                await transaction.RollbackAsync(CancellationToken.None);
            }
            else
            {
                await transaction.CommitAsync(CancellationToken.None);
            }
        }
        else
        {
            await ExecuteSeeder(cancellationToken);
        }

        async Task ExecuteSeeder(CancellationToken cancellationToken = default)
        {
            await seeder.SeedAsync(_context, cancellationToken);

            await history.AddAsync(new DataSeederHistory(id), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}