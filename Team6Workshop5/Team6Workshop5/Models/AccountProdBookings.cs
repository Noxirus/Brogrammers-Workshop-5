using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class AccountProdBookings
    {
        public string CustFirstName { get; set; }
        public string ProdName { get; set; }
        public decimal? BasePrice { get; set; }
        public int? BookingId { get; set; }
        
    }
}