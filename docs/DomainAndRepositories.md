### Domain Model and Repository Abstractions

Base Entity

- `Accounting.Domain.Abstraction.Entity`
  - Id: string
  - CreatedDate: DateTime
  - UpdatedDate: DateTime?

Entities

- Company
  - CompanyName: string
  - CompanyAddress?: string
  - IdentityNumber?: string
  - TaxDepartment?: string
  - PhoneNumber?: string
  - Email?: string
  - ServerName: string
  - DatabaseName: string
  - UserId: string
  - Password: string

- AppUser (IdentityUser<string>)
  - NameLastName: string
  - RefreshToken: string
  - RefreshTokenExpires: DateTime

- AppRole (IdentityRole<string>)
  - Code: string

- UniformChartOfAccount
  - Code: string
  - Name: string
  - Type: char // Ana Grup, Grup, Muavin

Repository Abstractions

- IRepository<T>
  - `void SetDbContextInstance(DbContext context)`
  - `DbSet<T> Entity { get; set; }`

- IQueryRepository<T>
  - `IQueryable<T> GetAll(bool isTracking = true)`
  - `IQueryable<T> GetWhere(Expression<Func<T,bool>> expression, bool isTracking = true)`
  - `Task<T> GetById(string id, bool isTracking = true)`
  - `Task<T> GetFirstByExpiression(Expression<Func<T,bool>> expression, bool isTracking = true)`
  - `Task<T> GetFirst(bool isTracking = true)`

- ICommandRepository<T>
  - `Task AddAsync(T entity)`
  - `Task AddRangeAsync(IEnumerable<T> entities)`
  - `void Update(T entity)`
  - `void UpdateRange(IEnumerable<T> entities)`
  - `Task RemoveById(string id)`
  - `void Remove(T entity)`
  - `void RemoveRange(IEnumerable<T> entities)`

Unit of Work & Context Service

- IUnitOfWork
  - `void SetDbContextInstance(DbContext context)`
  - `Task<int> SaveChangesAsync()`

- IContectService
  - `DbContext CreateDbContextInstance(string companyId)`

