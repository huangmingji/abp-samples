using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lemon.UserCenter.EntityFrameworkCore
{
    public class UserCenterDbContextFactory: IDesignTimeDbContextFactory<UserCenterDbContext>
    {
        public UserCenterDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<UserCenterDbContext>()
                .UseNpgsql(configuration.GetConnectionString("Default"));

            return new UserCenterDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}