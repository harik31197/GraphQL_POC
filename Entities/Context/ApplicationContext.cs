using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_DotNetCore.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountContextConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerContextConfiguration());            
            modelBuilder.ApplyConfiguration(new OwnerAccountsConfiguration());
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<OwnerAccounts> OwnerAccounts { get; set; }
    }
}
