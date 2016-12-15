using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CignaInsurance.Models;
using System.Data;

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
            //Let the customer to create a quote 
            if (Session["CustomerId"] == null)
            {
                TempData["ReasontoLogin"] = "Please login first to get a quote";
                return RedirectToAction("loginview", "login");
            }
            int custId = Convert.ToInt32(Session["CustomerId"]);
            Customer customer = new HealthInsuranceDB().Customers.Find(custId);
            CustomerQuotePlan CustWithQ = new CustomerQuotePlan() { cust = customer,
                quote = new Quote(),
                plan = new Plan()
            };
            ViewBag.City = new HealthInsuranceDB().Cities.Find(customer.CityID).CityName;
            ViewBag.State = new HealthInsuranceDB().States.Find(customer.CityID).StateName;
            return View(CustWithQ);
        }

        public ActionResult BuyQuote()
        {
            //Quote and Plan Information
            int QuoteId = Convert.ToInt32(Request.Form["QuoteID"]);
            int CustomerId = Convert.ToInt32(Request.Form["CustID"]);
            int Period = Convert.ToInt32(Request.Form["PayPeriod"]);
            int quotefee = 0;
            string quoteDescription = Request.Form["QuoteDescription"];
            string MedicalPlan = Request.Form["MedicalPlan"];
            string DentalPlan = Request.Form["DentalPlan"];
            string EyePlan = Request.Form["EyePlan"];
            string start = Request.Form["QuoteStartDate"];
            if (quoteDescription=="Silver")
            {
                quotefee = 200;
            }
            if (quoteDescription == "Gold")
            {
                quotefee = 300;
            }
            if (quoteDescription == "Platinum")
            {
                quotefee = 400;
            }
            //DAL Layer to access to the database 
            var HealthDB = new HealthInsuranceDB();
            Quote q = HealthDB.Quotes.Find(QuoteId);
            Customer CurrentCust = HealthDB.Customers.Find(CustomerId);
            //Handle Quote Problem
            if (q == null)
            {
                //Create a quote based on the information
                q = new Quote()
                {
                    QuoteName = quoteDescription + " " + CurrentCust.Firstname,
                    QuoteDescription = quoteDescription,
                    QuoteFee = quotefee * Period,
                    CustomerID = CustomerId,
                    StartDate = Convert.ToDateTime(start),
                    IsActive = true
                };
                q.EndDate = q.StartDate.Value.AddDays(Period * 30);
                q.ExpireDate = q.EndDate.Value.AddDays(30);
                try
                {
                    HealthDB.Quotes.Add(q);
                    HealthDB.SaveChanges();
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            else
            {
                q.QuoteName = quoteDescription + " " + CurrentCust.Firstname;
                q.QuoteDescription = quoteDescription;
                q.QuoteFee = quotefee * Period;
                q.CustomerID = CustomerId;
                q.StartDate = Convert.ToDateTime(start);
                q.IsActive = true;
                q.EndDate = q.StartDate.Value.AddDays(Period * 30);
                q.ExpireDate = q.EndDate.Value.AddDays(30);
                HealthDB.SaveChanges();
            }
            //Handle Plan Problem
            if (MedicalPlan != "")
            {
                Plan p = new Plan
                {
                    PlanTypeID = 1,
                    PlanFee = 60,
                    PlanDescription = CurrentCust.Firstname,
                    StartDate = Convert.ToDateTime(start),
                    CustomerID=CustomerId
                };
                p.EndDate = p.StartDate.AddDays(Period * 30);
                HealthDB.Plans.Add(p);
                HealthDB.SaveChanges();
            }
            if (DentalPlan != "")
            {
                Plan p = new Plan
                {
                    PlanTypeID = 2,
                    PlanFee = 70,
                    PlanDescription = CurrentCust.Firstname,
                    StartDate = Convert.ToDateTime(start),
                    CustomerID = CustomerId
                };
                p.EndDate = p.StartDate.AddDays(Period * 30);
                HealthDB.Plans.Add(p);
                HealthDB.SaveChanges();
            }
            if (EyePlan != "")
            {
                Plan p = new Plan
                {
                    PlanTypeID = 3,
                    PlanFee = 80,
                    PlanDescription = CurrentCust.Firstname,
                    StartDate = Convert.ToDateTime(start),
                    CustomerID = CustomerId
                };
                p.EndDate = p.StartDate.AddDays(Period * 30);
                HealthDB.Plans.Add(p);
                HealthDB.SaveChanges();
            }
            ViewBag.CustId = CurrentCust.CustomerID;
            ViewBag.QuoteId = q.QuoteID;
            return View();
        }
        [HttpPost]
        public JsonResult SaveQuote(string cid, string qid, string qsd, string ppd)
        {
            //Save the quote created to the database, if not
            int QuoteId = Convert.ToInt32(qid);
            int CustomerId = Convert.ToInt32(cid);
            int Period = Convert.ToInt32(ppd);
            var HealthDB = new HealthInsuranceDB();
            Quote q = HealthDB.Quotes.Find(QuoteId);
            Customer CurrentCust = HealthDB.Customers.Find(CustomerId);
            string start = qsd;
            if (q == null)
            {
                //Create a quote based on the information
                q = new Quote()
                {
                    QuoteName = "Regular " + CurrentCust.Firstname,
                    QuoteDescription = "Regular",
                    QuoteFee = 200 * Period,
                    CustomerID = CustomerId,
                    ExpireDate = DateTime.Now.AddDays(30),
                    IsActive = false
                };

                if (start != "")
                {
                    q.StartDate = Convert.ToDateTime(start);
                    q.EndDate = q.StartDate.Value.AddDays(Period * 30);
                };

                try
                {
                    HealthDB.Quotes.Add(q);
                    HealthDB.SaveChanges();
                }

                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
                }
            }
            else
            {
                //Update the quote information 
                q.QuoteFee = 200 * Period;
                q.CustomerID = CustomerId;
                q.IsActive = false;
                if (start != "")
                {
                    q.StartDate = Convert.ToDateTime(start);
                    q.EndDate = q.StartDate.Value.AddDays(Period * 30);
                };
                HealthDB.SaveChanges();
            }
            return Json(q.QuoteID, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RetrieveQuote()
        {
            int CustomerId= Convert.ToInt32(Session["CustomerId"]);
            var DB = new HealthInsuranceDB();
            Customer cust = DB.Customers.Find(CustomerId);
            return View(cust); 
        }

        public ActionResult RetrieveQuoteResult()
        {
            var DB = new HealthInsuranceDB();
            Customer customer = DB.Customers.Find(Convert.ToInt32(Request.Form["customerId"]));
            Quote q = DB.Quotes.Find(Convert.ToInt32(Request.Form["QuoteId"]));
            string errorMessage = "";
            if (customer == null)
            {
                errorMessage = "Sorry, Please Login to see your quote";
            }
            else if (q == null)
            {
                errorMessage = "Sorry, We haven't fount any quotes based on your quote id";
            }
            else if (q.CustomerID != customer.CustomerID)
            {
                errorMessage = "Sorry, this is not your quote";
            }
            if (errorMessage!="")
            {
                ViewBag.error = errorMessage;
                return View(customer);
            }
            CustomerQuotePlan CustWithQ = new CustomerQuotePlan()
            {
                cust = customer,
                quote = q,
                plan = new Plan()
            };
            if (q.StartDate != null)
            {
                ViewBag.StartDate = q.StartDate.Value.ToString("yyyy-MM-dd");
            }
            ViewBag.City = DB.Cities.Find(customer.CityID).CityName;
            ViewBag.State = DB.States.Find(customer.CityID).StateName;
            return View("AboutQuote", CustWithQ);
        }
    }
}