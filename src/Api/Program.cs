using Microsoft.AspNetCore.Mvc;
using TemplateService.Application;
using TemplateService.Application.Exceptions;
using TemplateService.Application.Services;
using TemplateService.Infrastructure;
using TemplateService.Infrastructure.Persistence;
using TemplateServices.Application.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddProblemDetails(o => o.CustomizeProblemDetails = ctx =>
{
    ctx.ProblemDetails.Detail = ctx.Exception?.Message;
    ctx.ProblemDetails.Status = ctx.Exception switch
    {
        NotFoundException => StatusCodes.Status404NotFound,
        _ => StatusCodes.Status500InternalServerError
    };
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated(); // Creates tables if they don't exist
    context.SeedData();
}

// Converts unhandled exceptions into Problem Details responses
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/templates", async (ITemplateService templateService) =>
{
    IEnumerable<TemplateDto> templates = await templateService.GetAllTemplates();
    return Results.Ok(templates);
})
.WithName("GetTemplates");

app.MapGet("/templates/{templateId}", async (string templateId, ITemplateService templateService) =>
{
    TemplateDto dto = await templateService.GetTemplateById(templateId);
    return Results.Ok(dto);
})
.WithName("GetTemplate");

app.MapPost("/templates/{templateId}/generate", async (
    string templateId,
    Dictionary<string, object> templateValues,
    ITemplateService templateService) =>
{
    string content = await templateService.GenerateFromTemplateAsync(templateId, templateValues);
    return Results.Ok(content);
})
.WithName("GenerateTemplate");

app.MapPost("/templates", async ([FromBody] TemplateDto dto, ITemplateService templateService) =>
{
    await templateService.CreateTemplate(dto);
    return Results.CreatedAtRoute("GetTemplate", new { TemplateId = dto.Id });
})
.WithName("CreateTemplate");

app.Run();

