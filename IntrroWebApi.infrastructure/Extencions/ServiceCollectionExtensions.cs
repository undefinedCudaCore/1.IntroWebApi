using IntroWebApi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IntroWebApi.Infrastructure.Extencions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services)
        {
            services.AddScoped<IFakeDbService, FakeDbService>();
            return services;
        }
    }
}
