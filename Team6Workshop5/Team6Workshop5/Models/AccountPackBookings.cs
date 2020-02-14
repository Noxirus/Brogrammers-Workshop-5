using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class AccountPackBookings
    {
        public string CustFirstName { get; set; }
        public string ProdName { get; set; }
        public decimal? BasePrice { get; set; }
        public string PkgName { get; set; }
        public decimal? PkgBasePrice { get; set; }
        public int? BookingId { get; set; }
        public string PRODCustFirstName { get; set; }
        public string PRODProdName { get; set; }
        public decimal? PRODBasePrice { get; set; }
        public int? PRODBookingId { get; set; }
    }
}