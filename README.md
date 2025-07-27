# Template Generator API

A simple REST API for storing and generating your personal code templates, boilerplate, and project structures.

## What's This For?

Stop copy-pasting the same code patterns over and over. Store your go-to templates (project structures, code snippets, config files) and generate them on demand with custom variables.

## Features

- **Store Templates**: Save your boilerplate code with placeholder variables
- **Generate Code**: Fill templates with actual values via API calls
- **Organize by Tags**: Group templates by language, framework, or purpose
- **Variable Substitution**: Use `{{variableName}}` placeholders in templates
- **Multiple Formats**: Support for single files or entire directory structures

## Quick Example

```bash
# Store a template
POST /templates
{
  "name": "professional-email",
  "tags": ["email", "business"],
  "content": "Hi {{recipientName}},\n\nI wanted to follow up on {{subject}}. {{mainMessage}}\n\nPlease let me know if you have any questions.\n\nBest regards,\n{{senderName}}"
}

# Generate from template
POST /templates/professional-email/generate
{
  "variables": {
    "recipientName": "John",
    "subject": "our meeting yesterday",
    "mainMessage": "Thanks for taking the time to discuss the project timeline. I'll send over the revised schedule by Friday.",
    "senderName": "Alex"
  }
}
# Returns: "Hi John,\n\nI wanted to follow up on our meeting yesterday..."
```

## Template Format

```json
{
  "id": "unique-template-name",
  "name": "Human readable template name",
  "description": "What this template does",
  "tags": ["tag1", "tag2"],
  "content": "Your template content with {{variables}}"
}
```

## Getting Started

1. Clone the repo
2. `dotnet run`
3. API available at `http://localhost:5000`
4. Check `/swagger` for interactive docs

