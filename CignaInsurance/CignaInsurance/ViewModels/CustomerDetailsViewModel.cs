using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CignaInsurance.Models;
namespace CignaInsurance.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public Customer CustomerDetail
        {
            get;
            set;
        }
        public City CityDetail
        {
            get;
            set;
        }
        public State StateDetail
        {
            get;
            set;
        }
    }
}