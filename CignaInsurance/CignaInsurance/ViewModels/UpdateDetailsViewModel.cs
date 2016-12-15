using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CignaInsurance.Models;
using CignaInsurance.ViewModels;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace CignaInsurance.ViewModels
{
    public class UpdateDetailsViewModel
    {
        public CustomerDetailsViewModel FullCustomerDetail
        {
            get;
            set;
        }
        public IEnumerable<SelectListItem> CityNames { get; set; }
        [Required(ErrorMessage ="City Name is required")]
        public int CitySelectedID { get; set; }
        public IEnumerable<SelectListItem> StateNames { get; set; }
        [Required(ErrorMessage ="State Name is required")]
        public int StateSelectedID { get; set; }
    }
}