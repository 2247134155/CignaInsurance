using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CignaInsurance.Models;
using System.Net;
using static CignaInsurance.Models.Customer;
using static CignaInsurance.Models.Claim;

namespace CignaInsurance.Controllers
{
    public class AccountController : Controller
    {   
        // GET: /Account
        public ActionResult index()
        {
            var Cust = (Customer)TempData["Customer"];
            if (Cust==null)
            {
                return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
            }
            
            var temp = new HealthInsuranceDB().Customers.Find(1);

            if (temp == null)
            {
                return HttpNotFound();
            }
            return View(temp);
        }

        public ActionResult DeclareClaim()
        {
            /*string custID = TempData["custID"].ToString();
            if (custID == null)
            {
                return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
            }

            Claim claim = Cladb.Claims.Find(custID);
            */
            return View();
            
        }

        public ActionResult UpdateAccount(int? id)
        {
            /*
            if (id == null)
            {
                return Redirect(ControllerContext.HttpContext.Request.UrlReferrer.ToString());
            }
            Customer cust = Custdb.Customers.Find(id);
            */
            return View();
            
            
        }
    }
}