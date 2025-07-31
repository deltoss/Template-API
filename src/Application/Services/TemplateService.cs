using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateService.Application.Repositories;
using TemplateService.Domain.Entities;
using TemplateServices.Application.DTOs;
using HandlebarsDotNet;

namespace TemplateService.Application.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _templateRepository;

        public TemplateService(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository ?? throw new ArgumentNullException(nameof(templateRepository));
        }

        public async Task CreateTemplate(TemplateDto dto)
        {
            await _templateRepository.CreateTemplateAsync(new Template()
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Content = dto.Content,
            });
        }

        public async Task<string> GenerateFromTemplateAsync(string templateId, IDictionary<string, object> templateValues)
        {
            Template template = await _templateRepository.GetTemplateByIdAsync(templateId);
            HandlebarsTemplate<object, object> hTemplate = Handlebars.Compile(template.Content);
            return hTemplate(templateValues);
        }

        public async Task<IEnumerable<TemplateDto>> GetAllTemplates()
        {
            var templates = await _templateRepository.GetAllTemplatesAsync();
            return templates.Select(x => new TemplateDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Content = x.Content,
            });
        }

        public async Task<TemplateDto> GetTemplateById(string id)
        {
            Template template = await _templateRepository.GetTemplateByIdAsync(id);
            return new TemplateDto()
            {
                Id = template.Id,
                Name = template.Name,
                Description = template.Description,
                Content = template.Content,
            };
        }
    }
}
