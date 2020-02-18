using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team6Workshop5.Models
{
    public class NEWAccountBookings
    {

        //PACKAGES
       
            public string PACKCustFirstName { get; set; }
            public string PACKProdName { get; set; }
            public decimal? PACKBasePrice { get; set; }
            public string PACKPkgName { get; set; }
            public decimal? PACKPkgBasePrice { get; set; }
            public int? PACKBookingId { get; set; }
            public decimal? PACKTotal { get; set; }
            public string PRODCustFirstName { get; set; }
            public string PRODProdName { get; set; }
            public decimal? PRODBasePrice { get; set; }
            public int? PRODBookingId { get; set; }
            public decimal? PRODTotal { get; set; }
    }
}