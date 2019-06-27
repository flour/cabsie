using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsie.API.Models
{
    public class UserVM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
