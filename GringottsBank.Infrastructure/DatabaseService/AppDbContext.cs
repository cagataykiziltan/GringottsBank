using GringottsBank.Infrastructure.DatabaseService.AccountRepositories;
using GringottsBank.Infrastructure.DatabaseService.CustomerRepositories;
using GringottsBank.Infrastructure.DatabaseService.TransactionRepositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace GringottsBank.Infrastructure.DatabaseService
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> optionsBuilder) : base(optionsBuilder)
        {
            

        }

        public DbSet<CustomerDbModel> Customer { get; set; }
        public DbSet<AccountDbModel> AccountTable { get; set; }
        public DbSet<TransactionDbModel> TransactionTable { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
            modelBuilder.Entity<CustomerDbModel>().ToTable("Customers");
            modelBuilder.Entity<AccountDbModel>().ToTable("Accounts");
            modelBuilder.Entity<TransactionDbModel>().ToTable("Transactions");

        }
    }

}
