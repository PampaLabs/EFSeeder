using Testcontainers.MsSql;

namespace EFSeeder.Test;

public class MsSqlServerContainerTest : IAsyncLifetime
{
    private readonly MsSqlContainer _msSqlContainer
        = new MsSqlBuilder().Build();

    protected MsSqlContainer MsSqlContainer => _msSqlContainer;

    public Task InitializeAsync()
        => _msSqlContainer.StartAsync();

    public Task DisposeAsync()
        => _msSqlContainer.DisposeAsync().AsTask();
}