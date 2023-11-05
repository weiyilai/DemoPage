using DemoPage.Repository.DbContexts;
using DemoPage.Repository.Repositories;
using DemoPage.Repository.Repositories.Interfaces;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DemoPage.Repository;

public static class ConfigureServices
{
    public static IServiceCollection AddRepository(
        this IServiceCollection services,
        IConfiguration configuration
        )
    {
        services.AddSingleton<SqliteDbContext, SqliteDbContext>(_ => 
        {
            return new SqliteDbContext(configuration.GetConnectionString("Sqlite"));
        });
        services.AddTransient<IOgImageRepository, OgImageRepository>();

        InitializeDatabase();

        return services;
    }

    async static Task InitializeDatabase()
    {
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        using (var db = new SqliteConnection($"Filename={path}\\demopage.db"))
        {
            db.Open();

            string tableCommand = @"
                DROP TABLE IF EXISTS DemoPage;
                CREATE TABLE IF NOT EXISTS DEMOPAGE(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name NVARCHAR(2048) NULL,
                    Ext VARCHAR(10) NULL,
                    LocalExt VARCHAR(10) NULL,
                    LocalMirrorFile INTEGER
                );

                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '1A',
                    '.jpg',
                    '',
                    1
                  );
                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '2B',
                    '',
                    '.png',
                    0
                  );
                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '3B',
                    '.jpg',
                    '.png',
                    0
                  );
                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '4A',
                    '.jpg',
                    '.gif',
                    0
                  );
                INSERT INTO DEMOPAGE (Name, Ext, LocalExt, LocalMirrorFile)
                VALUES (    
                    '5C',
                    '',
                    '',
                    1
                  );
                ";

            var createTable = new SqliteCommand(tableCommand, db);

            createTable.ExecuteReader();
        }
    }
}
