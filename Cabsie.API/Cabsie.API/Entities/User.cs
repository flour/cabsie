using Cabsie.API.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Cabsie.API.Entities
{
    public class User : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(50)]
        public string MiddleName { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
