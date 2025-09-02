### Configuration and Dependency Injection

Program startup (Accounting.WebApi/Program.cs)

- Registers installers via `InstallServices`
- Enables Swagger in Development
- Configures HTTPS redirection, Authentication, Authorization, and maps controllers
- Seeds default admin user if database has no users

JWT Options

- Options class: `Accounting.Infrastructure.Authentication.JwtOptions`
  - Issuer: string
  - Audience: string
  - SecretKey: string

- Binding: `JwtOptionsSetup` binds configuration section `Jwt` (case-insensitive)
- Validation: `JwtBearerOptionsSetup` enables issuer, audience, lifetime and signing key validation

Swagger

- Configured in `PresentationServiceInstaller`
- Adds JWT Bearer auth scheme and requirement

Persistence

- `PersistanceServiceInstaller`
  - Reads `ConnectionStrings:SqlServer`
  - Registers `AppDbContext` with SQL Server provider
  - Adds ASP.NET Identity stores and AutoMapper

DI Registration

- `InfrastructureDIServiceInstaller`
  - `IJwtProvider -> JwtProvider`

- `PersistanceDIServiceInstaller`
  - `IUnitOfWork -> UnitOfWork`
  - `IContectService -> ContextService`
  - `ICompanyService -> CompanyService`
  - `IUCAFService -> UCAFService`
  - `IRoleService -> RoleService`
  - `IUCAFCommandRepository -> UCAFCommandRepository`
  - `IUCAFQueryRepository -> UCAFQueryRepository`

Configuration example (`Accounting.WebApi/appsettings.json`)

```json
{
  "ConnectionStrings": {
    "SqlServer": "Data Source=SERVER;Initial Catalog=ACCOUNTING_MASTER;..."
  },
  "JWT": {
    "Issuer": "www.mysitem.com",
    "Audience": "www.yoursite.com",
    "SecretKey": "your-strong-secret"
  }
}
```

