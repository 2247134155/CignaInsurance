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
            return View();
        }

        public ActionResult Welcome()
        {
            var HIDB = new HealthInsuranceDB();
            return View(HIDB.Customers.ToList());
        }

        public ActionResult Redirects(int id)
        {
            Customer cust = new HealthInsuranceDB().Customers.Find(id);
            TempData["Customer"] = cust;
            return RedirectToAction("AboutQuote", "Quote");
        }
    }
}