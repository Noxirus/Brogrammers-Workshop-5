using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team6Workshop5.Models;

namespace Team6Workshop5.Controllers
{
    public class AccountBookingsController : Controller
    {
        List<NEWAccountBookings> accPackBookingsList = new List<NEWAccountBookings>();

        public ActionResult Pack()
        {
            accPackBookingsList = NewAccountBookingsDB.GetPackBookings();

            return View(accPackBookingsList);
        }

        // GET: AccountBookings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
    }
}
