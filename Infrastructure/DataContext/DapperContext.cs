using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    private readonly string context = "Host=localhost;Port=5432;Database=Job-db;User Id=postgres;Password=2810";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(context);
    }

}