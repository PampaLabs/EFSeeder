namespace EFSeeder;

internal class DataSeederHistory
{
    public string DataSeederId { get; set; } = default!;

    public DataSeederHistory()
    {
    }

    public DataSeederHistory(string dataSeederId)
    {
        DataSeederId = dataSeederId;
    }
}