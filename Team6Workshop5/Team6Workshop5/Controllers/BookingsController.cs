using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team6Workshop5.Models;

namespace Team6Workshop5.Controllers
{
    public class BookingsController : Controller
    {
        List<Bookings> bookings;
        // GET: Bookings
        public ActionResult Index()
        {
            bookings = BookingsDB.GetBookings();

            return View(bookings);
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bookings/Create
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

        // GET: Bookings/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bookings/Edit/5
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

        // GET: Bookings/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bookings/Delete/5
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
