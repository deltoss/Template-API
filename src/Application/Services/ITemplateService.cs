using System.Collections.Generic;
using System.Threading.Tasks;
using TemplateServices.Application.DTOs;

namespace TemplateService.Application.Services
{
    public interface ITemplateService
    {
        Task CreateTemplate(TemplateDto template);
        Task<IEnumerable<TemplateDto>> GetAllTemplates();
        Task<TemplateDto> GetTemplateById(string templateId);
        Task<string> GenerateFromTemplateAsync(string templateId, IDictionary<string, object> templateValues);
    }
}
