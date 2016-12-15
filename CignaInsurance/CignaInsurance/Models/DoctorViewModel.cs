using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CignaInsurance.Models
{
    public class DoctorViewModel
    {
        public int ID { get; set; }
        //[Key]
        public Doctor doc { get; set; }
        public City citys { get; set; }
        public State states { get; set; }
    }
}