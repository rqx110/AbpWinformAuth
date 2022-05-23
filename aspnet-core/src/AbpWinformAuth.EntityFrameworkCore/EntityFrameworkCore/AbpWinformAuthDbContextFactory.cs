using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace AbpWinformAuth.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class AbpWinformAuthDbContextFactory : IDesignTimeDbContextFactory<AbpWinformAuthDbContext>
{
    public AbpWinformAuthDbContext CreateDbContext(string[] args)
    {
        AbpWinformAuthEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AbpWinformAuthDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new AbpWinformAuthDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../AbpWinformAuth.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
