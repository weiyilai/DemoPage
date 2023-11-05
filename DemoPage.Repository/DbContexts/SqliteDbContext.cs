using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DemoPage.Repository.DbContexts;

public class SqliteDbContext : DbContext
{
    private readonly string _connectionString;

    public SqliteDbContext(
        string connectionString
        )
    {
        _connectionString = connectionString;
    }
    
    public IDbConnection Connection()
    {
        return new SqliteConnection(_connectionString);
    }
}
