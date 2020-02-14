using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class Bookings
    {
        public int? BookingId { get; set; }
        public int? PackageId { get; set; }

        public int? CustomerId { get; set; }
    }
}