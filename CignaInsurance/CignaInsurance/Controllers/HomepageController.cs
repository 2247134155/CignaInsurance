using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CignaInsurance.Models;
namespace CignaInsurance.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        public ActionResult Index()
        {
            if (Session["CustomerId"] != null)
            {
                ViewBag.LayoutCustomerID = Convert.ToInt32(Session["CustomerId"]);
            }
            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Redirects(int id)
        {
            Customer cust = new HealthInsuranceDB().Customers.Find(id);
            TempData["Customer"] = cust;
            return RedirectToAction("AboutQuote", "Quote");
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["CustomerId"] = null;
            return View("Index");
        }
    }
}