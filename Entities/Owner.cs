using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GraphQL_DotNetCore.Entities
{
    public class Owner
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public string Address { get; set; }

        //public ICollection<Account> Accounts { get; set; }
    }
}
