using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Team6Workshop5.Models;

namespace Team6Workshop5.Controllers
{
    public class CustomerController : Controller
    {
        Customer customer;
        // GET: Customer
        public ActionResult Index()
        {
            customer = CustomerDB.GetCustomerDetails(143); // needs to pass in a variable reference to the customer ID
            return View(customer);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                CustomerDB.CustomerRegister(customer);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer currentCust = CustomerDB.GetCustomerDetails(id);
            return View(currentCust);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer newCustomer)
        {
            try
            {
                Customer currentCust = CustomerDB.GetCustomerDetails(id);
                int count = CustomerDB.UpdateCustomer(currentCust, newCustomer);
                if (count == 0)// no update due to concurrency issue
                    TempData["errorMessage"] = "Update aborted. " +
                        "Another user changed or deleted this row";
                else
                    TempData["errorMessage"] = "";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
