using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CignaInsurance.Models;
using System.Net;
using static CignaInsurance.Models.Customer;
using static CignaInsurance.Models.Claim;
using CignaInsurance.ViewModels;

namespace CignaInsurance.Controllers
{
    public class AccountController : Controller
    {   
        // GET: /Account
        public ActionResult index()
        {
            //if (TempData["custID"] == null) return RedirectToAction("index", "Homepage");
            //TempData["custID"] = 1;
            if (Session["CustomerId"] == null)
            {
                TempData["ReasontoLogin"] = "Please login first to see your Account";
                return RedirectToAction("loginview", "login");
            }
            int custID = Convert.ToInt32(Session["CustomerId"]);
            //TempData.Keep("custID");
            var tempCustomer = new HealthInsuranceDB().Customers.Find(custID);
            var tempClaims = new HealthInsuranceDB().Claims.Where(c => c.CustomerID == 1).ToList();
            AccountDetailsViewModel viewModel = new AccountDetailsViewModel()
            {
                CustomerDetails = tempCustomer,
                ClaimsCollection = tempClaims
            };
            ViewBag.City = new HealthInsuranceDB().Cities.Find(tempCustomer.CityID).CityName;
            ViewBag.State = new HealthInsuranceDB().States.Find(tempCustomer.StateID).StateName;
            return View(viewModel);
        }

        public ActionResult DeclareClaim()
        {
            if (Session["CustomerId"] == null)
            {
                TempData["ReasontoLogin"] = "Please login first to Declare a Claim";
                return RedirectToAction("loginview", "login");
            }
            int custID = Convert.ToInt32(Session["CustomerId"]);
            var tempClaim = new HealthInsuranceDB().Claims.Create();
            tempClaim.CustomerID = custID;
            return View(tempClaim);
        }
        [HttpPost]
        public ActionResult DeclareClaim(Claim claim)
        {
            if (ModelState.IsValid)
            {
                var db = new HealthInsuranceDB();
                HashSet<Agent> agentSet = new HashSet<Agent>();
                foreach(var c in db.Agents)
                {
                    agentSet.Add(c);
                }
                List<Agent> agentList = agentSet.ToList();
                Random rand = new Random();
                int iup = agentList.Count() - 1;
                int idown = 0;
                int result = rand.Next(idown,iup);
                Agent temp = agentList.ElementAt(result);
                int agentID = temp.AgentID;

                db.Claims.Add(new Claim
                {
                    CustomerID = claim.CustomerID,
                    AgentID = agentID,
                    ClaimStatus = "Processing Claim",
                    DeclareDate = System.DateTime.Now,
                    AmountPaid = null,
                    PaidDate = null,
                    Description = claim.Description
                });
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(claim);
        }

        public ActionResult UpdateAccount()
        {
            if (Session["CustomerId"] == null)
            {
                TempData["ReasontoLogin"] = "Please login first to Update your Account";
                return RedirectToAction("loginview", "login");
            }
            int custID = Convert.ToInt32(Session["CustomerId"]);
            UpdateDetailsViewModel viewModel = new UpdateDetailsViewModel();
            CustomerDetailsViewModel viewModel2 = new CustomerDetailsViewModel();
            var tempCustomer = new HealthInsuranceDB().Customers.Find(custID);
            viewModel2.CustomerDetail = tempCustomer;
            viewModel2.CityDetail = new HealthInsuranceDB().Cities.Find(tempCustomer.CityID);
            viewModel2.StateDetail = new HealthInsuranceDB().States.Find(tempCustomer.StateID);
            viewModel.FullCustomerDetail = viewModel2;
            var cities = new HealthInsuranceDB().Cities;
            viewModel.CityNames = cities.Select(c => new SelectListItem
            {
                Text = c.CityName,
                Value = c.CityID.ToString()
            });
            var states = new HealthInsuranceDB().States;
            viewModel.StateNames = states.Select(s => new SelectListItem
            {
                Text = s.StateName,
                Value = s.StateID.ToString()
            });
            ViewBag.date = tempCustomer.DateofBirth;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult UpdateAccount(UpdateDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
                {

                DateTime date = viewModel.FullCustomerDetail.CustomerDetail.DateofBirth;
                var db = new HealthInsuranceDB();
                Customer tempCustomer = new Customer();
                tempCustomer = db.Customers.Find(viewModel.FullCustomerDetail.CustomerDetail.CustomerID);
                tempCustomer.CustomerID = viewModel.FullCustomerDetail.CustomerDetail.CustomerID;
                tempCustomer.Address = viewModel.FullCustomerDetail.CustomerDetail.Address;
                if (viewModel.FullCustomerDetail.CustomerDetail.Gender)
                {
                    tempCustomer.Gender = true;
                }
                else
                {
                    tempCustomer.Gender = false;
                }
                tempCustomer.DateofBirth = date;
                tempCustomer.Phone = viewModel.FullCustomerDetail.CustomerDetail.Phone;
                tempCustomer.DoctorID = viewModel.FullCustomerDetail.CustomerDetail.DoctorID;
                tempCustomer.Email = viewModel.FullCustomerDetail.CustomerDetail.Email;
                tempCustomer.Firstname = viewModel.FullCustomerDetail.CustomerDetail.Firstname;
                tempCustomer.Lastname = viewModel.FullCustomerDetail.CustomerDetail.Lastname;
                tempCustomer.SSN = viewModel.FullCustomerDetail.CustomerDetail.SSN;
                tempCustomer.Zip = viewModel.FullCustomerDetail.CustomerDetail.Zip;
                tempCustomer.UserID = viewModel.FullCustomerDetail.CustomerDetail.UserID;
                tempCustomer.CityID = viewModel.CitySelectedID;
                tempCustomer.StateID = viewModel.StateSelectedID;
                db.Entry(tempCustomer).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(viewModel);
        }

        public ActionResult Claims()
        {
            TempData["ReasontoLogin"] = "Please login first to Check your claim";
            if (Session["CustomerId"] == null)
            {
                return RedirectToAction("loginview", "login");
            }
            int custID = Convert.ToInt32(Session["CustomerId"]);
            ClaimDetailsViewModel viewModel = new ClaimDetailsViewModel();
            viewModel.AgentCollection = new HealthInsuranceDB().Agents;
            viewModel.ClaimsCollection = new HealthInsuranceDB().Claims.Where(c => c.CustomerID == custID).ToList();
            return View(viewModel);
        }

        public ActionResult DoctorDetail()
        {
            if (Session["CustomerId"] == null)
            {
                TempData["ReasontoLogin"] = "You have to login first to see Doctor Details";
                return RedirectToAction("loginview", "login");
            }
            int custID = Convert.ToInt32(Session["CustomerId"]);
            var tempCustomer = new HealthInsuranceDB().Customers.Find(custID);
            if (tempCustomer.DoctorID == null)
            {
                ViewBag.ErrorMsg = "You have not chosen a Doctor Yet";
                return View();
            }
            DoctorDetailsViewModel viewModel = new DoctorDetailsViewModel();
            var tempDoc = new HealthInsuranceDB().Doctors.Find(tempCustomer.DoctorID);
            var tempHospital = new HealthInsuranceDB().Hospitals.Find(tempDoc.HospitalID);
            viewModel.doctor = new HealthInsuranceDB().Doctors.Find(tempCustomer.DoctorID);
            viewModel.hospital = new HealthInsuranceDB().Hospitals.Find(tempDoc.HospitalID);
            ViewBag.City = new HealthInsuranceDB().Cities.Find(tempHospital.CityID).CityName;
            ViewBag.State = new HealthInsuranceDB().States.Find(tempHospital.StateID).StateName;
            return View(viewModel);
        }

        public ActionResult PlanDetail()
        {
            if (Session["CustomerId"] == null)
            {
                TempData["ReasontoLogin"] = "Please login first to see Plan Details";
                return RedirectToAction("loginview", "login");
            }
            int custID = Convert.ToInt32(Session["CustomerId"]);
            PlanDetailsModelView viewModel = new PlanDetailsModelView();
            var tempCustomer = new HealthInsuranceDB().Customers.Find(custID);
            //Bug here 
            
            viewModel.PlanCollections = new HealthInsuranceDB().Plans.Where(p => p.CustomerID == custID).ToList();
            viewModel.PlanTypeCollections = new HealthInsuranceDB().PlanTypes;
            return View(viewModel);
        }

    }
}