using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lemon.Account.EntityFrameworkCore.DbMigrations
{
    public class AccountDbMigrationsDbContextFactory: IDesignTimeDbContextFactory<AccountDbMigrationsDbContext>
    {
        public AccountDbMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AccountDbMigrationsDbContext>()
                .UseNpgsql(configuration.GetConnectionString("Default"));

            return new AccountDbMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables();

            return builder.Build();
        }
    }
}