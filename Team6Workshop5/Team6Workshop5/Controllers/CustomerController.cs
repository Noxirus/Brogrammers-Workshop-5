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
            int id = Convert.ToInt32(Session["UserID"]);
            
            customer = CustomerDB.GetCustomerDetails(id); // needs to pass in a variable reference to the customer ID
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
                var custInfo = CustomerDB.GetCustomerInfo(customer.UserName);


                if(custInfo != null)
                {
                    ViewBag.usertaken = "User ID Already Exist";
                    return View();
                }

                else
                {
                    customer.Password = Crypto.Hash(customer.Password);
                    CustomerDB.CustomerRegister(customer);

                    return RedirectToAction("Login");
                }


         


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
        public ActionResult Login()
        {
            CustomerLogin loginInfo = new CustomerLogin();

            return View(loginInfo);
        }

        [HttpPost]

        public ActionResult Login(CustomerLogin login)
        {
            var databaseUser = CustomerDB.CustomerLogin(login.UserName);

            if(ModelState.IsValid)
            {
                if (databaseUser is null)
                {
                    //ModelState.AddModelError("Error", "User Name is Registered");
                    ViewBag.invalid = "Invalid User";
                    return View();
                }
                
                else
                {
                    //if(databaseUser.Password != Crypto.Hash(login.Password))


                    if(string.Compare(Crypto.Hash(login.Password),databaseUser.Password)==0)
              
                    {
                        ViewBag.Password = "Invalid Password";
                        return View();
                    }

                    else
                    {
                        Session["UserID"] = databaseUser.CustomerId;

                    }
                    
                }
            }
           
            return RedirectToAction("Index","Customer");
        }

        public ActionResult Logout()
        {

            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}
