using Microsoft.EntityFrameworkCore;
using task.context;
using TaskManagerApp_Bunya.Data;
using TaskManagerApp_Bunya.Models;

namespace TaskManagerApp_Bunya.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureTASKContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<TASKContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void ConfigureApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
        }

        public static void ConfigureDataManagers(this IServiceCollection services)
        {
        }
    }
}
