using Microsoft.Extensions.DependencyInjection;
using TemplateService.Application.Services;

namespace TemplateService.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITemplateService, Services.TemplateService>();
            return services;
        }
    }
}
