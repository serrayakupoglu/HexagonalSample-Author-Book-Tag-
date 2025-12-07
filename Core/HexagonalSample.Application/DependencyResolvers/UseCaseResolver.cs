using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HexagonalSample.Application.DependencyResolvers
{
    public static class UseCaseResolver
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
        }
    }
}
