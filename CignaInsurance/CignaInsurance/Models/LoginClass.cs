using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Web.Mvc;


namespace CignaInsurance.Models
{
    public class Registration1
    {
        [Required]
        public string password { get; set; }
        [Required]
        public string repassword { get; set; }
        [Required]
        public string username { get; set; }
    }
    public class Registration
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string  lastname { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public string state { get; set; }
        [Required]
        
        public string zipcode { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public string SSN { get; set; }




    }
    public class MailModel
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public object Email { get; internal set; }
    }
    public class Passvalidation
    {
        [Required]
        public DateTime passvalidation { get; set; }
       
    }
    public class LoginClass
    {
        [Required]
        public string txtusername { get; set; }
        [Required]
        public string txtpassword { get; set; }


    }
    public class ForgetPass
    {
        [Required]
        public string username { get; set; }
    }
    public class Forgetusername
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public DateTime DOB { get; set; }

     

    }

   
}