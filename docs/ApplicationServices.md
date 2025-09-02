### Application Services and Abstractions

IJwtProvider (Accounting.Application.Abstractions)

- Signature
  - `Task<string> CreateTokenAsync(AppUser user, List<string> roles)`
- Behavior
  - Implemented by `Accounting.Infrastructure.Authentication.JwtProvider`
  - Produces a JWT token and updates user's RefreshToken/RefreshTokenExpires

ICompanyService (Accounting.Application.Services.AppServices)

- Methods
  - `Task CreateCompany(CreateCompanyRequest request)`
  - `Task MigrateCompanyDatabases()`
  - `Task<Company?> GetCompanyByName(string name)`
- Notes
  - Implemented by `Accounting.Persistance.Services.AppServices.CompanyService`
  - Uses `AppDbContext` and AutoMapper

IRoleService (Accounting.Application.Services.AppServices)

- Methods
  - `Task AddAsync(CreateRoleRequest request)`
  - `Task UpdateAsync(AppRole approle)`
  - `Task DeleteAsync(AppRole approle)`
  - `Task<IList<AppRole>> GetAllRolesAsync()`
  - `Task<AppRole> GetById(string id)`
  - `Task<AppRole> GetByCode(string code)`
- Notes
  - Implemented by `Accounting.Persistance.Services.AppServices.RoleService`

IUCAFService (Accounting.Application.Services.CompanyServices)

- Methods
  - `Task CreateUcafAsync(CreateUCAFRequest request)`
- Notes
  - Implemented by `Accounting.Persistance.Services.CompanyServices.UCAFService`

MediatR Requests/Responses

- Auth
  - `LoginRequest { EmailOrUserName, Password } -> LoginResponse { Token, Email, UserId, NameLastName }`

- Company
  - `CreateCompanyRequest { CompanyName, ServerName, DatabaseName, UserId, Password } -> CreateCompanyResponse { Message }`
  - `MigrateCompanyDatabasesRequest -> MigrateCompanyDatabasesResponse { Message }`

- Roles
  - `CreateRoleRequest { Name, Code } -> CreateRoleResponse { Message }`
  - `UpdateRoleRequest { Id, Name, Code } -> UpdateRoleResponse { Message }`
  - `DeleteRoleRequest { Id } -> DeleteRoleResponse { Message }`
  - `GetAllRolesRequest -> GetAllRolesResponse { Roles: AppRole[] }`

- UCAF
  - `CreateUCAFRequest { Code, Name, Type, CompanyId } -> CreateUCAFResponse { Message }`

Usage Example (MediatR)

```csharp
var response = await mediator.Send(new CreateCompanyRequest {
    CompanyName = "ACME Ltd",
    ServerName = "SQL01",
    DatabaseName = "ACME_DB",
    UserId = "sa",
    Password = "StrongP@ssw0rd"
});
```

