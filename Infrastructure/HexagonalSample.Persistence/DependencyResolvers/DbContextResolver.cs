using HexagonalSample.Persistence.EFData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HexagonalSample.Persistence.DependencyResolvers
{
    public static class DbContextResolver
    {
        public static void AddDbContextService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("MyConnection")));
        }
    }
}
