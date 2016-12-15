using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CignaInsurance.Models;
using CignaInsurance.Dal;

namespace CignaInsurance.Controllers
{
    public class DoctorController : Controller
    {
        private HealthInsuranceDB storeDB = new HealthInsuranceDB();


        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FindADoctor()
        {
            //TempData["UserID"] = -1;  //Guest
            // get data from DB
            var HIDB = new HealthInsuranceDB();
            // Connect DB to view model
            var viewModel = from o in HIDB.Doctors
                            join o2 in HIDB.Cities on o.CityID equals o2.CityID
                            join o3 in HIDB.States on o.StateID equals o3.StateID
                            where o.Firstname.Contains("-1")
                            select new DoctorViewModel { doc = o, citys = o2, states = o3 };
            return View("FindADoctor", viewModel);
        }

        public ActionResult Search()
        {
            string serachName = Request.Form["SerName"];
            string serachType = Request.Form["SerType"];
            string serachCity = Request.Form["SerCity"];
            var HIDB = new HealthInsuranceDB();
            var viewModel = from o in HIDB.Doctors
                            join o2 in HIDB.Cities on o.CityID equals o2.CityID
                            join o3 in HIDB.States on o.StateID equals o3.StateID
                            where o.Firstname.Contains(serachName)
                            where o.DoctorType.Contains(serachType)
                            where o2.CityName.Contains(serachCity)
                            select new DoctorViewModel { doc = o, citys = o2, states = o3 };
            return View("FindADoctor", viewModel);
        }

        public ActionResult DoctorDetail(int id)
        {

            var HIDB = new HealthInsuranceDB();
            TempData["DoctorID"] = id;
            var viewModel = from o in HIDB.Doctors
                            join o2 in HIDB.Cities on o.CityID equals o2.CityID
                            join o3 in HIDB.States on o.StateID equals o3.StateID
                            where o.DoctorID.Equals(id)
                            select new DoctorViewModel { doc = o, citys = o2, states = o3 };
            return View("DoctorDetail", viewModel);
        }

        public ActionResult DoctorDetailPopup(int id)
        {
            var HIDB = new HealthInsuranceDB();
            TempData["DoctorID"] = id;
            var viewModel = from o in HIDB.Doctors
                            join o2 in HIDB.Cities on o.CityID equals o2.CityID
                            join o3 in HIDB.States on o.StateID equals o3.StateID
                            where o.DoctorID.Equals(id)
                            select new DoctorViewModel { doc = o, citys = o2, states = o3 };
            return View("DoctorDetailPopup", viewModel);
        }

        public ActionResult FinishChooseDoctor()
        {
            if (Session["CustomerId"] != null)
            {
                int id = (Int32)TempData["DoctorID"];
                int MyId = Convert.ToInt32(Session["CustomerId"]);
                ViewData["DoctorID"] = TempData["DoctorID"];
                ViewData["UserID"] = MyId;
                CustomerDal Dal = new CustomerDal();
                Customer ll = Dal.Customer.FirstOrDefault(x => x.CustomerID == MyId); //wrong lane
                ll.DoctorID = id;
                Dal.SaveChanges();
                return View("FinishChooseDoctor");
            }else
            {
                return View("FinishChooseDoctorGuest");
            }

        }
    }
}