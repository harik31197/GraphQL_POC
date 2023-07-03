using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace GraphQL_DotNetCore.Entities
{
    public class OwnerContextConfiguration : IEntityTypeConfiguration<Owner>
    {        
        public OwnerContextConfiguration()
        {
            
        }

        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder
              .HasData(
                new Owner
                {
                    Id = 1,
                    Name = "John",
                    Address = "Chennai",
                    Email = "John@gmail.com",
                    Phone = "9898324233",
                    DOB = Convert.ToDateTime("01/01/1990")
                },
                new Owner
                {
                    Id = 2,
                    Name = "Smith",
                    Address = "Pune",
                    Email = "Smith@gmail.com",
                    Phone = "9898312344",
                    DOB = Convert.ToDateTime("01/01/1990")
                }
            );
        }
    }
}