using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GraphQL_DotNetCore.Entities
{
    public class OwnerAccountsConfiguration : IEntityTypeConfiguration<OwnerAccounts>
    {
        public OwnerAccountsConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<OwnerAccounts> builder)
        {
            builder
              .HasData(
                new OwnerAccounts
                {
                    Id = 1,
                    OwnerId = 1,
                    AccountId = 1
                },
                new OwnerAccounts
                {
                    Id = 2,
                    OwnerId = 2,
                    AccountId = 1
                }
            );
        }
    }
}
