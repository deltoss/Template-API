using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TemplateService.Application.Exceptions;
using TemplateService.Application.Repositories;
using TemplateService.Domain.Entities;
using TemplateService.Infrastructure.Persistence;

namespace TemplateService.Infrastructure.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        private readonly AppDbContext _context;

        public TemplateRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task<IEnumerable<Template>> GetAllTemplatesAsync()
        {
            return Task.FromResult<IEnumerable<Template>>(_context.Templates);
        }

        public async Task<Template> GetTemplateByIdAsync(string id)
        {
            Template? template = await _context.Templates.FindAsync(id);
            if (template == null)
            {
                throw new NotFoundException($"Template with id of \"{id}\" wasn't found");
            }
            return template;
        }

        public async Task CreateTemplateAsync(Template template)
        {
            await _context.Templates.AddAsync(template);
            await _context.SaveChangesAsync();
        }
    }
}
