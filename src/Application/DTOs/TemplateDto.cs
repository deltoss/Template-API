using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TemplateServices.Application.DTOs
{
    public class TemplateDto
    {
        public string Id { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string Content { get; set; } = string.Empty;
    }
}
