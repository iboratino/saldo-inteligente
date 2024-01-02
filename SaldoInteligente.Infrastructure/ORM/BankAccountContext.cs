
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaldoInteligente.Domain.Entities;
using SaldoInteligente.Infrastructure.ORM.Mapping;

namespace SaldoInteligente.Infrastructure.ORM
{
    public partial class BankAccountContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public BankAccountContext() 
        {            
        }

        public BankAccountContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public DbSet<BalanceCheckingStatementEntity> BalanceCheckingStatement { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {            
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = configuration.GetConnectionString("SaldoInteligente");                
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }            
            optionsBuilder.EnableSensitiveDataLogging(true);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BalanceCheckingStatementMapping());
        }
    }
}
