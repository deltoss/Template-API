using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TemplateService.Application.Repositories;
using TemplateService.Infrastructure.Persistence;
using TemplateService.Infrastructure.Repositories;

namespace TemplateService.Infrastructure
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configs)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configs.GetConnectionString("AppConnection")));

            services.AddScoped<ITemplateRepository, TemplateRepository>();
            return services;
        }
    }
}
