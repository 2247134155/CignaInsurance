using System;
using System.Linq;
using System.Web.Mvc;
using CignaInsurance.Models;
using System.Net.Mail;

namespace CignaInsurance.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        //HealthInsuranceDB
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult passwordvalidation(Passvalidation pv)
        {
            var database = new HealthInsuranceDB();
            var cust = database.Customers.ToList();
            var g = Session["userid"];
            foreach (var s in cust)
            {
                if (s.UserID.ToString() == g.ToString())
                {
                    if (s.DateofBirth.Date == pv.passvalidation.Date)
                    {
                        return RedirectToAction("sendmail", "login");
                    }
                }
            }
            return View();
        }
        public ActionResult forgetpassword(ForgetPass fp)
        {
            if (ModelState.IsValid)
            {
                var database = new HealthInsuranceDB();
                var user = database.Users.ToList();
                foreach (var s in user)
                {
                    if (s.UserName == fp.username)
                    {
                        Session["userid"] = s.UserID.ToString();

                        return View("passwordvalidation");
                    }
                }
            }
            return View();
        }
        public ActionResult loginview(LoginClass lg)
        {
            if (TempData["ReasontoLogin"] != null)
            {
                ViewBag.Error = (string)TempData["ReasontoLogin"];
            }
            if (ModelState.IsValid)
            {
                var database = new HealthInsuranceDB();
                bool t = false;
                var user = database.Users.ToList();
                Session["database"] = database;
                ViewBag.database = database;
                int test = 0;
                foreach (var s in user)
                {
                    if (s.UserName == lg.txtusername && s.Password == lg.txtpassword)
                    {
                        t = true;
                        Session["UserId"] = s.UserID;
                        foreach (Customer cust in database.Customers)
                        {
                            if (cust.UserID == s.UserID)
                            {
                                Session["CustomerId"] = cust.CustomerID;
                                test = Convert.ToInt32(Session["CustomerId"]);
                                break;
                            }
                        }
                        break;
                    }
                }
                if (t == true)
                {
                    return RedirectToAction("Index", "Homepage");
                }
                ViewData["wrong"] = 1;
                return View();
            }
            else return View();
        }
        public ActionResult sendmail(MailModel _objModelMail)
        {
            var s = (Forgetusername)TempData["forgetusername"];
            var d = Session["userid"].ToString();
            string id = "";
            var database = new HealthInsuranceDB();
            var User = database.Customers.ToList();
            if (s != null)
            {
                foreach (var sa in User)
                {
                    if ((s.Name == sa.Firstname) && (s.Lastname == sa.Lastname))
                    {
                        id = sa.UserID.ToString();
                        _objModelMail.To = sa.Email.ToString();
                    }
                }


                if (id != "")
                {
                    var tmp = database.Users.ToList();
                    foreach (var sa in tmp)
                    {
                        if (sa.UserID.ToString() == id)
                            _objModelMail.Body = "your user name is : " + sa.UserName.ToString();// aqui es k va el password
                        _objModelMail.Subject = "Forget username";
                    }

                }
                // part to send the msg
                _objModelMail.From = "cignaprojectgroup@gmail.com";
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("cignaprojectgroup", "MvcProject02");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("homepage");



            }


            else if (d!=null)
            {
                foreach (var sa in User)
                {
                    if (sa.UserID.ToString() ==d )
                    {
                        id = sa.UserID.ToString();
                        _objModelMail.To = sa.Email.ToString();
                    }
                }


                if (id != "")
                {
                    var tmp = database.Users.ToList();
                    foreach (var sa in tmp)
                    {
                        if (sa.UserID.ToString() == id)
                            _objModelMail.Body = "your user passwor is : " + sa.Password.ToString();// aqui es k va el password
                        _objModelMail.Subject = "Forget password";
                    }

                }
                // part to send the msg
                _objModelMail.From = "cignaprojectgroup@gmail.com";
                MailMessage mail = new MailMessage();
                mail.To.Add(_objModelMail.To);
                mail.From = new MailAddress(_objModelMail.From);
                mail.Subject = _objModelMail.Subject;
                string Body = _objModelMail.Body;
                mail.Body = Body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential
                ("cignaprojectgroup", "MvcProject02");// Enter seders User name and password
                smtp.EnableSsl = true;
                smtp.Send(mail);
                return View("homepage");



            }






            return View("homepage");
        }
        public ActionResult forgetusername(Forgetusername fn)

        {

            var database = new HealthInsuranceDB();
            var c = database.Customers.ToList();
            foreach (var s in c)
            {
                if ((s.Firstname == fn.Name) && (s.Lastname == fn.Lastname) && (s.DateofBirth.Date == fn.DOB.Date))
                {
                    TempData["forgetusername"] = fn;
                    return RedirectToAction("sendmail", "login");
                    // return View("sendmail");
                }
            }

            return View();
            //  return View("sendmail");
        }
        public ActionResult registrationview(Registration r)
        {
            if (TempData["userid"] == null)
            {
                return View("preregistration");
            }
            else

            if (ModelState.IsValid)
            {




                var database = new HealthInsuranceDB();
                var cc = database.Customers.ToList();
                var c = new HealthInsuranceDB().Customers.Create();
              
                // cheking to see if phone , username, and email are unique
               
                foreach (var h in cc)
                {
                    if (h.Email==r.email ||h.Phone== r.phone || h.SSN == r.SSN)
                    {
                        ViewBag.error = " check your email, phone or ssn ";
                        return View();
                    }
                }



                // end of cheking for unique 



                c.UserID = Convert.ToInt32(TempData["userid"]); // int int 
                c.Address = r.address; // string nvarchar(20);
                c.DateofBirth = DateTime.Now; //Convert.ToDateTime( "1990-08-01");
                c.Email = r.email; // string nvarchar(100)
                c.Firstname = r.name; // string nvarchar(20)
                c.Lastname = r.lastname; // nvarchar(20) string
                //should check for unique
                c.SSN = r.SSN;//string nvarchar(20)
                              // c.DoctorID          = null;
//should check for unique
                c.Phone = r.phone;//nvarchar(20)
                //CityID and StateID should be set with user input
                c.CityID = 5; // int
                c.StateID = 3;// int
                c.Zip = r.zipcode;
                //What if user type into a "Male", female then? 
                if (r.gender == "man")
                {
                    c.Gender = false;
                }
                else c.Gender = true;  // boolean bit
               
                database.Customers.Add(c);
                database.SaveChanges();

                return View("homepage");
            }
            else
                TempData.Keep("userid");

            return View();
        }
        public ActionResult preregistration(Registration1 r)
        {

            if (ModelState.IsValid)
            {

                var database = new HealthInsuranceDB();
                var s = new HealthInsuranceDB().Users.Create();
              
                var cc = database.Users.ToList();
             

                // cheking to see if phone , username, and email are unique

                foreach (var h in cc)
                {
                    if (h.UserName == r.username ) 
                    {
                        ViewBag.error = " Username already exist";
                        return View();
                    }
                }



                // end of cheking for unique 


                if (r.username != null)
                {
                    if (r.password != r.repassword)
                        return View();
                    s.UserName = r.username;
                    s.Password = r.password;
                    s.CreID = 1;

                    database.Users.Add(s);
                    database.SaveChanges();
                    var database1 = new HealthInsuranceDB();
                    var user = database.Users.ToList();
                    int x = -1;
                    foreach (var item in user)
                    {
                        if (item.UserName == s.UserName && item.Password == s.Password)
                            x = item.UserID;
                    }

                    TempData["userid"] = x;
                    return View("registrationview");
                }
            }
            if (TempData["userid"] != null)
                return View("registrationview");
            return View();
        }
        public ActionResult jquerypractica()
        {
            return View();
        }
    }
}