using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsie.API.ViewModels
{
    public class UserVM
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public UserType UserType { get; set; } = UserType.Passenger;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

    }
}
