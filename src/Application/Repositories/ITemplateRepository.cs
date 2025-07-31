using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateService.Domain.Entities;
using TemplateServices.Application.DTOs;

namespace TemplateService.Application.Repositories
{
    public interface ITemplateRepository
    {
        Task CreateTemplateAsync(Template template);
        Task<IEnumerable<Template>> GetAllTemplatesAsync();
        Task<Template> GetTemplateByIdAsync(string id);
    }
}
