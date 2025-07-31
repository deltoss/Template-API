using System.Linq;
using TemplateService.Domain.Entities;

namespace TemplateService.Infrastructure.Persistence
{
    public static class DatabaseSeeder
    {
        public static void SeedData(this AppDbContext context)
        {
            if (context.Templates.Any()) return;

            context.Templates.AddRange(
                new Template()
                {
                    Id = "email-thank-you",
                    Name = "Email: Thank You",
                    Description = "Email to express great gratitude",
                    Content = "Thank you {{name}} for your help with {{project}}!",
                },
                new Template()
                {
                    Id = "html-basic-report",
                    Name = "HTML: Basic Report",
                    Description = "HTML template for reports",
                    Content = "# Basic Report \n{{data}}",
                },
                new Template()
                {
                    Id = "email-work-signature",
                    Name = "Email: Work Signature",
                    Description = "Professional work signature for emails to your colleagues",
                    Content = "Best regards, {{name}}, the resident of the office",
                }
            );
            context.SaveChanges();
        }
    }
}
