using Npgsql;

namespace Infrastructure.DataContext;

public class DapperContext
{
    readonly string _connectionString="Host=localhost;Port=5432;Database=CompanyDB;User Id=postgres;Password=******;";

    public NpgsqlConnection GetConnection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}