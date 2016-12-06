using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CignaInsurance.Models;
namespace CignaInsurance.Controllers
{
    public class QuoteController : Controller
    {
        // GET: Quote
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutQuote()
        {
            var customer = (Customer)TempData["Customer"];
            if (customer == null)
            {
                return RedirectToAction("Index","Homepage");
            }
            CustomerQuotePlan CustWithQ = new CustomerQuotePlan() { cust = customer,
                quote = new Quote(),
                plan = new Plan()};
            return View();
        }
        public ActionResult RetrieveQuote(string id)
        {
            var quote = new HealthInsuranceDB().Quotes.Find(id);
            if (quote == null)
            {
                return View();
            }
            ViewBag.quotes = quote;
            return View("AboutQuote", quote.CustomerID);
        }
        public ActionResult SaveQuote(CustomerQuotePlan CustWithQ)
        {
            if (CustWithQ.quote == null)
            {

            }
            else
            {

            }
            return View(CustWithQ);
        }
        public ActionResult AddPlan(CustomerQuotePlan CustWithQ)
        {
            return View(CustWithQ);
        }
        
        public ActionResult Test()
        {
            var cust = (Customer)TempData["Customer"];
            if (cust == null)
            {
                return RedirectToAction("Index", "Homepage");
            }
            return View(cust);
        }
    }
}