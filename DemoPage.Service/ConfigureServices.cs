using DemoPage.Service.OgImageServices;
using DemoPage.Service.OgImageServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DemoPage.Service
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddService(
            this IServiceCollection services
        )
        {
            services.AddTransient<IOgImageService, OgImageService>();

            return services;
        }
    }
}
