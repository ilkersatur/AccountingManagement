using Accounting.Domain.Abstraction;
using Accounting.Domain.AppEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Accounting.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private string ConnectionString = "";

        public CompanyDbContext(Company company = null)
        {
            if (company != null)
            {
                if (company.UserId == null)
                {
                    ConnectionString = $"" +
                        $"Data Source={company.ServerName};" +
                        $"Initial Catalog={company.DatabaseName};" +
                        $"Integrated Security=True;" +
                        $"Connect Timeout=30;Encrypt=True;" +
                        $"Trust Server Certificate=True;" +
                        $"Application Intent=ReadWrite;" +
                        $"Multi Subnet Failover=False";
                }
                else
                {
                    ConnectionString = $"" +
                        $"Data Source={company.ServerName};" +
                        $"Initial Catalog={company.DatabaseName};" +
                        $"User Id={company.UserId};" +
                        $"Password={company.UserId};" +
                        $"Integrated Security=True;" +
                        $"Connect Timeout=30;" +
                        $"Encrypt=True;" +
                        $"Trust Server Certificate=True;" +
                        $"Application Intent=ReadWrite;" +
                        $"Multi Subnet Failover=False";
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            private readonly AppDbContext dbContext;

            public CompanyDbContext CreateDbContext(string[] args)
            {

                return new CompanyDbContext();
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Accounting.Domain.Abstraction.Entity>();

            foreach (var entry in entries)
            {
                // Yeni bir ekleme işlemi yapıyorsak
                if (entry.State == EntityState.Added)
                {
                    entry.Property(p => p.CreatedDate)
                        .CurrentValue = DateTime.Now;
                }

                // Kaydı güncelleme işlemi yapıyorsak
                if (entry.State == EntityState.Modified)
                {
                    entry.Property(p => p.UpdatedDate)
                        .CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
