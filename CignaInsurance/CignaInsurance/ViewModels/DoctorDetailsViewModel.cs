using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CignaInsurance.Models;
namespace CignaInsurance.ViewModels
{
    public class DoctorDetailsViewModel
    {
        public Doctor doctor
        {
            get;
            set;
        }
        public Hospital hospital
        {
            get;
            set;
        }
    }
}