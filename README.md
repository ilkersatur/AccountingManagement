## Accounting Management - Documentation Index

This repository contains a layered .NET 8 solution for an Accounting Management system. Below are quick links to the full documentation and getting started steps.

- docs/Overview.md
- docs/Endpoints.md
- docs/ApplicationServices.md
- docs/DomainAndRepositories.md
- docs/Configuration.md

### Quick Start

1. Prerequisites
   - .NET 8 SDK
   - SQL Server instance

2. Configure appsettings
   - Update `Accounting.WebApi/appsettings.json` connection string `ConnectionStrings:SqlServer`
   - Set JWT settings under `JWT: Issuer, Audience, SecretKey`

3. Run the API
   - Set startup project to `Accounting.WebApi`
   - `dotnet run --project Accounting.WebApi`
   - Swagger UI available in Development at `/swagger`

4. First-time seed
   - On start, an admin user is created: Email `admin@admin.com`, Password `Password12*`

5. Auth flow
   - Obtain token via `POST /api/Auth/Login`
   - Use `Authorization: Bearer <token>` for protected endpoints

See the docs/ directory for detailed API specs and examples.

### Examples

- Login
  ```bash
  curl -s -X POST http://localhost:5000/api/Auth/Login \
    -H 'Content-Type: application/json' \
    -d '{"EmailOrUserName":"admin@admin.com","Password":"Password12*"}'
  ```

- Create Company
  ```bash
  curl -s -X POST http://localhost:5000/api/Companies/CreateCompany \
    -H 'Authorization: Bearer $TOKEN' \
    -H 'Content-Type: application/json' \
    -d '{
      "CompanyName": "ACME Ltd",
      "ServerName": "SQL01",
      "DatabaseName": "ACME_DB",
      "UserId": "sa",
      "Password": "StrongP@ssw0rd"
    }'
  ```


