### Overview

The solution follows a clean, layered architecture:

- Accounting.WebApi: Host, DI installers, Swagger, authentication/authorization
- Accounting.Presentation: ASP.NET Core MVC controllers and HTTP endpoints
- Accounting.Application: Use cases (MediatR requests/handlers), DTOs, service abstractions
- Accounting.Infrastructure: Cross-cutting concerns (JWT provider, options)
- Accounting.Persistance: EF Core DbContexts, repositories, service implementations, AutoMapper profiles
- Accounting.Domain: Entities, repository abstractions, unit of work

Routing convention

- Base route is `api/[controller]` from `Accounting.Presentation.Abstraction.ApiController`
- Controllers use action-based routes via `[HttpPost("[action]")]` or `[HttpGet("[action]")]`

Authentication

- JWT Bearer configured with `JwtOptions` (Issuer, Audience, SecretKey)
- Swagger is set up with Bearer support in Development

Key capabilities

- Authentication: login issues JWT tokens
- Company management: create company, migrate company databases
- Roles management: create, update, delete, list roles
- Uniform Chart of Accounts (UCAF): create entries per company

