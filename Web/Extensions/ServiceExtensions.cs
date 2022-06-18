using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;
using Persistence.Repositories;
using Services;
using Services.Abstractions;

namespace Web.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
        }
        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryDbContext>(o => o.UseMySql(connectionString, MySqlServerVersion.LatestSupportedServerVersion));
        }
    }
}
