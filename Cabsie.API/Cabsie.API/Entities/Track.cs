using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cabsie.API.Entities
{
    public class Track : BaseEntity
    {
        public string FromCity { get; set; }
        public string FromStreet { get; set; }
        public string FromHouse { get; set; }
        public string FromBlock { get; set; }

        public string ToCity { get; set; }
        public string ToStreet { get; set; }
        public string ToHouse { get; set; }
        public string ToBlock { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public Guid PassengerId { get; set; }
        public User Passenger { get; set; }

        public Guid DriverId { get; set; }
        public User Driver { get; set; }

    }
}
