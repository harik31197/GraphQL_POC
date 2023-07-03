using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GraphQL_DotNetCore.Entities
{
    public class AccountContextConfiguration : IEntityTypeConfiguration<Account>
    {        

        public AccountContextConfiguration()
        {
           
        }

        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder
                .HasData(
                new Account
                {
                    Id = 1,
                    Type = "Cash",
                    Description = "Cash account for our users",                    
                },
                new Account
                {
                    Id = 2,
                    Type = "Savings",
                    Description = "Savings account for our users",                    
                },
                new Account
                {
                    Id = 3,
                    Type = "Income",
                    Description = "Income account for our users",                    
                },
                new Account
                {
                    Id = 4,
                    Type = "Expense",
                    Description = "Expense account for our users",
                }

           );
        }
    }
}
