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
        List<AccountProdBookings> accProdBookingsList = new List<AccountProdBookings>();
        // GET: AccountBookings
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Pack()
        {
            accPackBookingsList = NewAccountBookingsDB.GetPackBookings();

            return View(accPackBookingsList);
        }

        public ActionResult Prod()
        {
            accProdBookingsList = AccountBookingsDB.GetProdBookings();

            return View(accProdBookingsList);
        }

        // GET: AccountBookings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountBookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountBookings/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountBookings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountBookings/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountBookings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountBookings/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
