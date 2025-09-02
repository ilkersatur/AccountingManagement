### HTTP API Endpoints

Base URL: `/api`

AuthController (`/api/Auth`)

- POST `/Login`
  - Request body (application/json):
    - EmailOrUserName: string
    - Password: string
  - Response 200:
    - Token: string
    - Email: string
    - UserId: string
    - NameLastName: string
  - Example
    ```http
    POST /api/Auth/Login HTTP/1.1
    Content-Type: application/json

    {
      "EmailOrUserName": "admin@admin.com",
      "Password": "Password12*"
    }
    ```

CompaniesController (`/api/Companies`)

- POST `/CreateCompany`
  - Request body:
    - CompanyName: string (required)
    - ServerName: string (required)
    - DatabaseName: string (required)
    - UserId: string (required)
    - Password: string (required)
  - Response 200:
    - Message: string
  - Example
    ```http
    POST /api/Companies/CreateCompany HTTP/1.1
    Content-Type: application/json
    Authorization: Bearer <token>

    {
      "CompanyName": "ACME Ltd",
      "ServerName": "SQL01",
      "DatabaseName": "ACME_DB",
      "UserId": "sa",
      "Password": "StrongP@ssw0rd"
    }
    ```

- POST `/MigrateCompanyDatabases`
  - Request: empty body
  - Response 200:
    - Message: string
  - Notes: Iterates all companies and applies EF Core migrations against company databases

RolesController (`/api/Roles`)

- POST `/CreateRole`
  - Request body:
    - Name: string (required)
    - Code: string (required)
  - Response 200:
    - Message: string

- POST `/UpdateRole`
  - Request body:
    - Id: string (required)
    - Name: string (required)
    - Code: string (required)
  - Response 200:
    - Message: string

- POST `/DeleteRole`
  - Request body:
    - Id: string (required)
  - Response 200:
    - Message: string

- GET `/GetAllRoles`
  - Response 200:
    - Roles: AppRole[]
  - Notes: `AppRole` inherits from `IdentityRole<string>` and includes `Code`

UCAFsController (`/api/UCAFs`)

- POST `/CreateUCAF`
  - Request body:
    - Code: string (required)
    - Name: string (required)
    - Type: char (required) // A: Ana Grup, G: Grup, M: Muavin (domain comment)
    - CompanyId: string (required)
  - Response 200:
    - Message: string

Authentication & Authorization

- JWT Bearer is required for endpoints except login
- Add header: `Authorization: Bearer <token>`

