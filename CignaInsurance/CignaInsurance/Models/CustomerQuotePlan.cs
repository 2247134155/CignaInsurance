using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CignaInsurance.Models
{
    public class CustomerQuotePlan
    {
        [Key]
        public Customer cust{ get; set; }

        public Quote quote { get; set; }

        public Plan plan { get; set; }
    }
}