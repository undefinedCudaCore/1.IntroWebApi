using IntroWepApi.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IntroWepApi.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IBusinessLogicService, BusinessLogicService>();
            return services;
        }
    }
}
