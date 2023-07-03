using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQL_DotNetCore.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Type is required")]
        public string Type { get; set; }
        public string Description { get; set; }        
    }
}
