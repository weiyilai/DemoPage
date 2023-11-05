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

        return services;
    }
}
