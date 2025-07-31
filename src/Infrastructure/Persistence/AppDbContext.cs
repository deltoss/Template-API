using Microsoft.EntityFrameworkCore;
using TemplateService.Domain.Entities;

namespace TemplateService.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Template> Templates { get; set; }
    }
}
